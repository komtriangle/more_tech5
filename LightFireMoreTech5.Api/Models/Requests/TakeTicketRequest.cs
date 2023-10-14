using LightFireMoreTech5.Api.Models.Enums;

namespace LightFireMoreTech5.Api.Models.Requests;
public class TakeTicketRequest
{
    public long OfficeId { get; set; }
    public long ServiceId { get; set; }
    public DateTime Time { get; set; }
    public DateTime WayTime { get; set; }
    public TakeTicketType TakeTicketType { get; set; }
}