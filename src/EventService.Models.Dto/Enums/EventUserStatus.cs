using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UniversityHelper.EventService.Models.Dto.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum EventUserStatus
{
  Invited,
  Refused,
  Participant,
  Discarded
}
