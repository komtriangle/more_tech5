using LightFireMoreTech5.Data;
using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LightFireMoreTech5.Data.Seeders;
public class ServiceSeeder
{
    public static void SeedServices(BankServicesContext context)
    {
        if (context.Services.Any())
            return;

        context.Services.AddRange(
            new Service
            {
                Name = "Установка приложения СберБанк Онлайн на iPhone",
                Category = ServiceCategory.NonFinance,
                Type = ServiceType.Both,
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
        context.SaveChanges();
    }
}