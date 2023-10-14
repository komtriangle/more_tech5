namespace LightFireMoreTech5.Api.Models.Requests;
public class UpdateOfficeWorkloadRequest
{
    public long OfficeId { get; set; }
    public long ServiceId { get; set; }
    public bool IsCompleted { get; set; }
}