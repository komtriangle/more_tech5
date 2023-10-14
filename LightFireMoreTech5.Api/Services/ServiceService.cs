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
	private readonly IDbContextFactory<BankServicesContext> _dbContextFactory;
	private readonly ILogger<ServiceService> _logger;

    public ServiceService(
	   IDbContextFactory<BankServicesContext> dbContextFactory,
		ILogger<ServiceService> logger)
    {
		_dbContextFactory = dbContextFactory ??
            throw new ArgumentNullException(nameof(dbContextFactory));

        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }
    public async Task<List<ServiceModel>> GetServicesAsync(ServiceType serviceType, CancellationToken token)
    {
        try
        {
			using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
				var services = await context.Services.Where(x => x.Type == serviceType).ToListAsync();

				if (services == null)
				{
					return new List<ServiceModel>();
				}

				var ans = new List<ServiceModel>();

				foreach (var item in services)
				{
					ans.Add(new ServiceModel
					{
						Id = item.Id,
						Name = item.Name,
						Category = item.Category,
						IsAvailableOnline = item.AvailableOnline,
						OnlineLink = item.OnlineLink,
					});
				}

				return ans;
			}
			

        }
        catch (Exception ex)
        {
            string message = "Ошибка во время получения офиса";
            _logger.LogError(ex, message);
            throw new Exception(message);
        }
    }

}