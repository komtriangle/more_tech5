using LightFireMoreTech5.Data.Enums;

namespace LightFireMoreTech5.Data.Entities;
public class Service
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool AvailableOnline { get; set; } = false;
    public string OnlineLink { get; set; } = string.Empty;
    public ServiceType Type { get; set; }
    public ServiceCategory Category { get; set; }
    public int AverageWaitTime { get; set; }

    public ICollection<OfficeService> OfficeServices { get; set; }
}