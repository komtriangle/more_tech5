using LightFireMoreTech5.Data.Enums;

namespace LightFireMoreTech5.Data.Entities;
public class Service
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ServiceType  Type { get; set; }
}