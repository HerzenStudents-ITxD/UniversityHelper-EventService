using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerzenHelper.Models.Broker.Enums;
using HerzenHelper.EventService.Broker.Requests.Interfaces;
using HerzenHelper.Core.BrokerSupport.Helpers;
using HerzenHelper.Models.Broker.Models.File;
using HerzenHelper.Models.Broker.Requests.File;
using HerzenHelper.Models.Broker.Responses.File;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace HerzenHelper.EventService.Broker.Requests;

public class FileService : IFileService
{
  private readonly ILogger<FileService> _logger;
  private readonly IRequestClient<IGetFilesRequest> _rcGetFiles;

  public FileService(
    ILogger<FileService> logger,
    IRequestClient<IGetFilesRequest> rcGetFiles)
  {
    _logger = logger;
    _rcGetFiles = rcGetFiles;
  }

  public async Task<List<FileCharacteristicsData>> GetFilesCharacteristicsAsync(List<Guid> filesIds, List<string> errors = null)
  {
    if (filesIds is null || !filesIds.Any())
    {
      return null;
    }

    return (await RequestHandler.ProcessRequest<IGetFilesRequest, IGetFilesResponse>(
        _rcGetFiles,
        IGetFilesRequest.CreateObj(FileSource.Event, filesIds),
        errors,
        _logger))
      ?.FilesCharacteristicsData;
  }
}
