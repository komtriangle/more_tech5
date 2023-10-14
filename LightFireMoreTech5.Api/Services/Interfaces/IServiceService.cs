using LightFireMoreTech5.Data.Enums;
namespace LightFireMoreTech5.Api.Services.Interfaces;
public interface IServiceService
{
    Task<List<ServiceModel>> GetServicesAsync(ServiceType serviceType, CancellationToken token);
}