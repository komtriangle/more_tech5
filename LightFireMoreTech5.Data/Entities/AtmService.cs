using System.ComponentModel.DataAnnotations.Schema;

namespace LightFireMoreTech5.Data.Entities;
public class AtmService
{
    [ForeignKey("atms")] public long atmId { get; set; }
    public Atm Atm { get; set; }
    [ForeignKey("services")] public long serviceId { get; set; }
    public Service Service { get; set; }
}