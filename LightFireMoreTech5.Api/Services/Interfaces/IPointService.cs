using LightFireMoreTech5.Models;

namespace LightFireMoreTech5.Services.Interfaces
{
	public interface IPointService
	{
		Task<OfficeModel?> GetOfficeByIdAsync(long id, CancellationToken token);

		Task<AtmModel?> GetAtmByIdAsync(long id, CancellationToken token);
		Task<BankPoint[]> GetPointsInRadiusAsync(double latitude, double longitude, double radius, List<long> serviceIds, CancellationToken token);
	}
}
