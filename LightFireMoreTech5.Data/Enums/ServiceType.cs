namespace LightFireMoreTech5.Data.Enums;
public enum ServiceType
{
    Physical, // Услуга для физических лиц
    Legal,    // Услуга для юридических лиц
    Both = Physical | Legal, // Обе услуги
    All
}
