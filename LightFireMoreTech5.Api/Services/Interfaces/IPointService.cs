using LightFireMoreTech5.Api.Models.Requests;
using LightFireMoreTech5.Models;

namespace LightFireMoreTech5.Services.Interfaces
{
	public interface IPointService
	{
		Task<OfficeModel?> GetOfficeByIdAsync(long id, CancellationToken token);

		Task<AtmModel?> GetAtmByIdAsync(long id, CancellationToken token);
		Task<BankPoint[]> GetPointsInRadiusAsync(double latitude, double longitude, double radius, List<long> serviceIds, CancellationToken token);
		Task UpdateOfficeWorkloadAsync(UpdateOfficeWorkloadRequest request, CancellationToken token);
		Task<int> GetOfficeServiceWorkload(long officeId, long serviceId, CancellationToken token);
	}
}
