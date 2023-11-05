using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using HealthChecks.UI.Client;
using HerzenHelper.EventService.Broker.Configuration;
using HerzenHelper.EventService.Business.Helpers;
using HerzenHelper.EventService.Data.Provider.MsSql.Ef;
using HerzenHelper.Core.BrokerSupport.Configurations;
using HerzenHelper.Core.BrokerSupport.Extensions;
using HerzenHelper.Core.BrokerSupport.Middlewares.Token;
using HerzenHelper.Core.Configurations;
using HerzenHelper.Core.EFSupport.Extensions;
using HerzenHelper.Core.EFSupport.Helpers;
using HerzenHelper.Core.Extensions;
using HerzenHelper.Core.Middlewares.ApiInformation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace HerzenHelper.EventService;

public class Startup : BaseApiInfo
{
  private readonly BaseServiceInfoConfig _serviceInfoConfig;
  private readonly RabbitMqConfig _rabbitMqConfig;

  private void CreateUsersBirthdays(IApplicationBuilder app)
  {
    var scope = app.ApplicationServices.CreateScope();
    var usersBirthdaysGetter = scope.ServiceProvider.GetRequiredService<UsersBirthdaysGetter>();

    usersBirthdaysGetter.Start();
  }

  private void RemoveEvents(IApplicationBuilder app)
  {
    var scope = app.ApplicationServices.CreateScope();
    var eventsRemover = scope.ServiceProvider.GetRequiredService<EventsRemover>();

    eventsRemover.Start();
  }

  public const string CorsPolicyName = "LtDoCorsPolicy";
  public IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;

    _serviceInfoConfig = Configuration
      .GetSection(BaseServiceInfoConfig.SectionName)
      .Get<BaseServiceInfoConfig>();

    _rabbitMqConfig = Configuration
      .GetSection(BaseRabbitMqConfig.SectionName)
      .Get<RabbitMqConfig>();

    Version = "2.0.1";
    Description = "EventService is an API that intended to work with events.";
    StartTime = DateTime.UtcNow;
    ApiName = $"HerzenHelper - {_serviceInfoConfig.Name}";
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddPolicy(
        CorsPolicyName,
        builder =>
        {
          builder
          .AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
        });
    });

    string dbConnStr = ConnectionStringHandler.Get(Configuration);

    services.AddDbContext<EventServiceDbContext>(options =>
    {
      options.UseSqlServer(dbConnStr);
    });

    services.AddHttpContextAccessor();

    services.AddHealthChecks()
      .AddRabbitMqCheck()
      .AddSqlServer(dbConnStr);

    services.Configure<TokenConfiguration>(Configuration.GetSection("CheckTokenMiddleware"));
    services.Configure<BaseServiceInfoConfig>(Configuration.GetSection(BaseServiceInfoConfig.SectionName));
    services.Configure<BaseRabbitMqConfig>(Configuration.GetSection(BaseRabbitMqConfig.SectionName));

    services.AddBusinessObjects();

    services.ConfigureMassTransit(_rabbitMqConfig);

    services.AddTransient<UsersBirthdaysGetter>();
    services.AddTransient<EventsRemover>();

    services.AddControllers()
      .AddJsonOptions(options =>
     {
       options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     })
      .AddNewtonsoftJson();
  }

  public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
  {
    app.UpdateDatabase<EventServiceDbContext>();

    CreateUsersBirthdays(app);

    RemoveEvents(app);

    app.UseForwardedHeaders();

    app.UseExceptionsHandler(loggerFactory);

    app.UseApiInformation();

    app.UseRouting();

    app.UseMiddleware<TokenMiddleware>();

    app.UseCors(CorsPolicyName);

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers().RequireCors(CorsPolicyName);
      endpoints.MapHealthChecks($"/{_serviceInfoConfig.Id}/hc", new HealthCheckOptions
      {
        ResultStatusCodes = new Dictionary<HealthStatus, int>
        {
          { HealthStatus.Unhealthy, 200 },
          { HealthStatus.Healthy, 200 },
          { HealthStatus.Degraded, 200 },
        },
        Predicate = check => check.Name != "masstransit-bus",
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
      });
    });
  }
}
