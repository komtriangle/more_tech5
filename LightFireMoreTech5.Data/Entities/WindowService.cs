using System.ComponentModel.DataAnnotations.Schema;

namespace LightFireMoreTech5.Data.Entities;
public class WindowService
{
    [ForeignKey("windows")] public long windowId { get; set; }
    public Window Window { get; set; }
    [ForeignKey("services")] public long serviceId { get; set; }
    public Service Service { get; set; }
}