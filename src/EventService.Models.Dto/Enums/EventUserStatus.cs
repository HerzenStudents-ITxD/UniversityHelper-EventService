using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HerzenHelper.EventService.Models.Dto.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum EventUserStatus
{
  Invited,
  Refused,
  Participant,
  Discarded
}
