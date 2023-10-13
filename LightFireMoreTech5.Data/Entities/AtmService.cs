using System.ComponentModel.DataAnnotations.Schema;

namespace LightFireMoreTech5.Data.Entities;
public class AtmService
{
    [ForeignKey("atms")] public int atmId { get; set; }
    public Atm Atm { get; set; }
    [ForeignKey("services")] public int serviceId { get; set; }
    public Service Service { get; set; }
}