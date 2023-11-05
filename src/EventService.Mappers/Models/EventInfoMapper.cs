using System.Linq;
using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Mappers.Models;

public class EventInfoMapper : IEventInfoMapper
{
  private readonly ICategoryInfoMapper _categoryInfoMapper;

  public EventInfoMapper(ICategoryInfoMapper categoryInfoMapper)
  {
    _categoryInfoMapper = categoryInfoMapper;
  }

  public EventInfo Map(DbEvent dbEvent)
  {
    return dbEvent is null
      ? null
      : new EventInfo
      {
        Id = dbEvent.Id,
        Name = dbEvent.Name,
        Description = dbEvent.Description,
        Date = dbEvent.Date,
        EventsCategories = dbEvent.EventsCategories.Select(ec => _categoryInfoMapper.Map(ec.Category)).ToList()
      };
  }
}
