namespace LightFireMoreTech5.Data.Enums;
public class ServiceModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ServiceType Type { get; set; }
    public bool IsAvailableOnline { get; set; }
    public string OnlineLink { get; set; }
    public ServiceCategory Category { get; set; }
}