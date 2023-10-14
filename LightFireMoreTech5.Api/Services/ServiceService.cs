using System;
using LightFireMoreTech5.Data;
using LightFireMoreTech5.Models.Enums;
using LightFireMoreTech5.Services.Interfaces;
using LightFireMoreTech5.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using LightFireMoreTech5.Data.Enums;
namespace LightFireMoreTech5.Api.Services;
public class ServiceService : IServiceService
{
    private readonly BankServicesContext _context;
    private readonly ILogger<ServiceService> _logger;

    public ServiceService(
        BankServicesContext context,
        ILogger<ServiceService> logger)
    {
        _context = context ??
            throw new ArgumentNullException(nameof(context));

        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }
    public async Task<List<ServiceModel>> GetServicesAsync(ServiceType serviceType, CancellationToken token)
    {
        try
        {
            var services = await _context.Services.Where(x => x.Type == serviceType).ToListAsync();

            if (services == null)
            {
                return null;
            }

            var ans = new List<ServiceModel>();

            foreach (var item in services)
            {
                ans.Add(new ServiceModel { Id = item.Id, Name = item.Name, Category = item.Category });
            }

            return ans;

        }
        catch (Exception ex)
        {
            string message = "Ошибка во время получения офиса";
            _logger.LogError(ex, message);
            throw new Exception(message);
        }
    }

}