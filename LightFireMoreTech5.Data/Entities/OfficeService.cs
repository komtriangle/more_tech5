using System.ComponentModel.DataAnnotations.Schema;

namespace LightFireMoreTech5.Data.Entities;
public class OfficeService
{
    [ForeignKey("offices")] public int officeId { get; set; }
    public Office Office { get; set; }
    [ForeignKey("services")] public int serviceId { get; set; }
    public Service Service { get; set; }
}