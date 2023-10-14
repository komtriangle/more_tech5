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
        await SeedOfficeWindowToDB(context);
        await SeedWindowServiceToDB(context, services);
    }

    private async static Task<List<Service>> SeedServicesToDB(BankServicesContext context)
    {
        var services = await context.Services.ToListAsync();
        if (services.Any())
            return services;
        var random = new Random();

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
                Name = "Установка приложения на iPhone",
                Category = ServiceCategory.NonFinance,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
                  },
		new Service
			{
                Name = "ВТБ-вклад в рублях",
                Category = ServiceCategory.Investments,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/vtb-vklad-r/",
                Type = ServiceType.Physical,
                AverageWaitTime = random.Next(1, 10)
			},
			new Service
			{
				Name = "ВТБ-вклад в юанях",
				Category = ServiceCategory.Investments,
				AvailableOnline = true,
				OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/vtb-vklad-y/",
				Type = ServiceType.Physical,
                AverageWaitTime = random.Next(1, 10)
			},
            new Service
            {
                Name = "Накопительный счет \"Копилка\"",
                Category = ServiceCategory.Investments,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/nakopitelny-schet-kopilka/",
                Type = ServiceType.Physical,
                AverageWaitTime = random.Next(1, 10)
			},
            new Service
            {
                Name = "Вклад \"Новое время\"",
				Category = ServiceCategory.Investments,
				AvailableOnline = true,
				OnlineLink = @"https://www.vtb.ru/personal/vklady-i-scheta/novoe-vremya/",
				Type = ServiceType.Physical,
                AverageWaitTime = random.Next(1, 10)
			},
            new Service
            {
                Name = "Рассчетный счет для вашего бизнеса",
                Category = ServiceCategory.BankAccounts,
                AvailableOnline = false,
                Type = ServiceType.Legal,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service{
                Name = "Универсальная карта для бизнеса",
                Category = ServiceCategory.Cards,
                AvailableOnline = false,
                Type = ServiceType.Legal,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Экспресс-креди",
                Category = ServiceCategory.Credits,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/malyj-biznes/kredity-i-garantii/express-online/",
                Type = ServiceType.Legal,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Рассчетный счет для ИП",
                Category = ServiceCategory.BankAccounts,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/malyj-biznes/otkryt-schet/otkryt-schet-ip/",
                Type = ServiceType.Legal,
                AverageWaitTime = random.Next(1, 10)
			},
            new Service
            {
                Name = "Рассчетный счет для ООО",
                Category = ServiceCategory.BankAccounts,
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/malyj-biznes/otkryt-schet/otkryt-schet-ooo/",
                Type = ServiceType.Legal,
                AverageWaitTime = random.Next(1, 10)
			},
			new Service
            {
                Name = "КАСКО (подбор и оформление полиса)",
                Category = ServiceCategory.NonFinance,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "ОСАГО (подбор и оформление полиса)",
                Category = ServiceCategory.NonFinance,
                AverageWaitTime = random.Next(1, 10)
                AvailableOnline = true,
                OnlineLink = @"https://www.vtb.ru/personal/drugie-uslugi/strahovye-i-servisnye-produkty/osago/",
				        Type = ServiceType.Both,

            },
            new Service
            {
                Name = "Кофе в ВТБ",
                Category = ServiceCategory.NonFinance,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Переводы в рублях",
                Category = ServiceCategory.Transfers,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Переводы в иностранной валюте",
                Category = ServiceCategory.Transfers,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Сберегательные сертификаты банка",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Покупка монет из драгоценных металлов",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Продажа монет из драгоценных металлов",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Обезличенные металлические счета",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Предоставление в аренду индивидуальных сейфов",
                Category = ServiceCategory.Deposits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Кредитные карты",
                Category = ServiceCategory.Cards,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Дебетовые карты",
                Category = ServiceCategory.Cards,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Консультирование по ипотечным кредитам",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Выдача и оформление ипотечных кредитов",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Оформление и выдача потребительских кредитов",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Оформление и выдача автокредитов",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
            },
            new Service
            {
                Name = "Военная ипотека",
                Category = ServiceCategory.Credits,
                Type = ServiceType.Both,
                AverageWaitTime = random.Next(1, 10)
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
    public static async Task SeedOfficeWindowToDB(BankServicesContext context)
    {
        var windows = await context.Windows.ToListAsync();
        if (windows.Any())
            return;

        var officeIds = await context.Offices.Select(o => o.Id).ToListAsync();

        var random = new Random();

        foreach (var officeId in officeIds)
        {
            int numberOfWindows = random.Next(1, windows.Count + 1);

            var randomServiceIndices = Enumerable.Range(0, windows.Count).OrderBy(x => random.Next()).Take(numberOfWindows);

            foreach (var windowIndex in randomServiceIndices)
            {
                var window = new Window
                {
                    officeId = officeId,
                };
                windows.Add(window);
            }
        }

        context.Windows.AddRange(windows);
        await context.SaveChangesAsync();
    }
    public static async Task SeedWindowServiceToDB(BankServicesContext context, List<Service> services)
    {
        var WindowServices = await context.WindowServices.ToListAsync();
        if (WindowServices.Any())
            return;

        var serviceIds = services.Select(s => s.Id).ToList();
        var windowIds = await context.Windows.Select(o => o.Id).ToListAsync();

        var random = new Random();

        foreach (var windowId in windowIds)
        {
            int numberOfServices = random.Next(1, services.Count + 1);

            var randomServiceIndices = Enumerable.Range(0, services.Count).OrderBy(x => random.Next()).Take(numberOfServices);

            foreach (var serviceIndex in randomServiceIndices)
            {
                var windowService = new WindowService
                {
                    windowId = windowId,
                    serviceId = services[serviceIndex].Id
                };
                WindowServices.Add(windowService);
            }
        }

        context.WindowServices.AddRange(WindowServices);
        await context.SaveChangesAsync();
    }
}