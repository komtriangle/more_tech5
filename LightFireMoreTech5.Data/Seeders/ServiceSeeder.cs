using LightFireMoreTech5.Data;
using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LightFireMoreTech5.Data.Seeders;
public class ServiceSeeder
{
    public static async Task SeedServices(BankServicesContext context)
    {
        var services = await SeedServicesToDB(context);
        await SeedOfficeServicesToDB(context, services);
    }

    private async static Task<List<Service>> SeedServicesToDB(BankServicesContext context)
    {
        var services = await context.Services.ToListAsync();
        if (services.Any())
            return services;

        context.Services.AddRange(
			new Service
			{
				Name = "Открытие ИИС",
				Category = ServiceCategory.Investments,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/investicii/iis/",
				Type = ServiceType.Physical,
			},
            new Service
            {
                Name = "ВТБ-вклад в рублях",
                Category = ServiceCategory.Investments,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/vtb-vklad-r/",
                Type = ServiceType.Physical,
			},
			new Service
			{
				Name = "ВТБ-вклад в юанях",
				Category = ServiceCategory.Investments,
				AvailableOnline = true,
				OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/vtb-vklad-y/",
				Type = ServiceType.Physical,
			},
            new Service
            {
                Name = "Накопительный счет \"Копилка\"",
                Category = ServiceCategory.Investments,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/nakopitelny-schet-kopilka/",
                Type = ServiceType.Physical,
			},
            new Service
            {
                Name = "Вклад \"Новое время\"",
				Category = ServiceCategory.Investments,
				AvailableOnline = true,
				OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/novoe-vremya/",
				Type = ServiceType.Physical
			},
            new Service
            {
                Name = "Рассчетный счет для вашего бизнеса",
                Category = ServiceCategory.BankAccounts,
                AvailableOnline = false,
                Type = ServiceType.Legal
            },
            new Service{
                Name = "Универсальная карта для бизнеса",
                Category = ServiceCategory.Cards,
                AvailableOnline = false,
                Type = ServiceType.Legal
            },
            new Service
            {
                Name = "Экспресс-креди",
                Category = ServiceCategory.Credits,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/malyj-biznes/kredity-i-garantii/express-online/",
                Type = ServiceType.Legal
            },
            new Service
            {
                Name = "Рассчетный счет для ИП",
                Category = ServiceCategory.BankAccounts,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/malyj-biznes/otkryt-schet/otkryt-schet-ip/",
                Type = ServiceType.Legal
			},
            new Service
            {
                Name = "Рассчетный счет для ООО",
                Category = ServiceCategory.BankAccounts,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/malyj-biznes/otkryt-schet/otkryt-schet-ooo/",
                Type = ServiceType.Legal
			},
			new Service
            {
                Name = "КАСКО (подбор и оформление полиса)",
                Category = ServiceCategory.NonFinance,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "ОСАГО (подбор и оформление полиса)",
                Category = ServiceCategory.NonFinance,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/drugie-uslugi/strahovye-i-servisnye-produkty/osago/",
				Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Кофе в ВТБ",
                Category = ServiceCategory.NonFinance,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Переводы в рублях",
                Category = ServiceCategory.Transfers,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Переводы в иностранной валюте",
                Category = ServiceCategory.Transfers,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Сберегательные сертификаты банка",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Покупка монет из драгоценных металлов",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Продажа монет из драгоценных металлов",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Обезличенные металлические счета",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Предоставление в аренду индивидуальных сейфов",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Кредитные карты",
                Category = ServiceCategory.Cards,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Дебетовые карты",
                Category = ServiceCategory.Cards,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Консультирование по ипотечным кредитам",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Выдача и оформление ипотечных кредитов",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Оформление и выдача потребительских кредитов",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Оформление и выдача автокредитов",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
            },
            new Service
            {
                Name = "Военная ипотека",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
            });
        await context.SaveChangesAsync();
        return context.Services.ToList();
    }

    public static async Task SeedOfficeServicesToDB(BankServicesContext context, List<Service> services)
    {
        var officeServices = await context.OfficeServices.ToListAsync();
        if (officeServices.Any())
            return;

        var serviceIds = services.Select(s => s.Id).ToList();
        var officeIds = await context.Offices.Select(o => o.Id).ToListAsync();

        var random = new Random();

        foreach (var officeId in officeIds)
        {
            int numberOfServices = random.Next(1, services.Count + 1);

            var randomServiceIndices = Enumerable.Range(0, services.Count).OrderBy(x => random.Next()).Take(numberOfServices);

            foreach (var serviceIndex in randomServiceIndices)
            {
                var officeService = new OfficeService
                {
                    officeId = officeId,
                    serviceId = services[serviceIndex].Id
                };
                officeServices.Add(officeService);
            }
        }

        context.OfficeServices.AddRange(officeServices);
        await context.SaveChangesAsync();
    }
}