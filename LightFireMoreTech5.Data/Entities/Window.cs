using System.ComponentModel.DataAnnotations.Schema;
using LightFireMoreTech5.Data.Enums;

namespace LightFireMoreTech5.Data.Entities;
public class Window
{
    public long Id { get; set; }
    public int BusyTime { get; set; }
    [ForeignKey("offices")] public long officeId { get; set; }
    public Office Office { get; set; }
    public List<OfficeService> OfficeServices { get; set; }
}