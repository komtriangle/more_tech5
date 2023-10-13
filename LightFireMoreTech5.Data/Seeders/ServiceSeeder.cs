using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LightFireMoreTech5.Data.Seeders;
public class ServiceSeeder
{
    public static void SeedServices(IServiceProvider serviceProvider)
    {
        using (var context = new BankServicesContext(serviceProvider.GetRequiredService<DbContextOptions<BankServicesContext>>()))
        {
            if (context.Services.Any())
                return;

            context.Services.AddRange(
                new Service
                {
                    Name = "Кресло-коляска",
                },
                new Service
                {
                    Name = "Слепые",
                },
                new Service
                {
                    Name = "NFC для банковских карт",
                },
                new Service
                {
                    Name = "QR-код считывания",
                },
                new Service
                {
                    Name = "Поддерживает USD",
                },
                new Service
                {
                    Name = "Поддерживает плату в RUB",
                },
                new Service
                {
                    Name = "Поддерживает EUR",
                },
                new Service
                {
                    Name = "Поддерживает RUB",
                });

            context.SaveChanges();
        }
    }
}