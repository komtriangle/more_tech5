
﻿using LightFireMoreTech5.Api.Models.Requests;
using LightFireMoreTech5.Models;
﻿using LightFireMoreTech5.Models;
using LightFireMoreTech5.Models.Routes;

namespace LightFireMoreTech5.Services.Interfaces
{
	public interface IPointService
	{
		Task<OfficeModel?> GetOfficeByIdAsync(long id, CancellationToken token);

		Task<AtmModel?> GetAtmByIdAsync(long id, CancellationToken token);
		Task<PointsInRadiusModel> GetPointsInRadiusAsync(double latitude, double longitude, double radius, List<long> serviceIds, CancellationToken token);
		Task UpdateOfficeWorkloadAsync(UpdateOfficeWorkloadRequest request, CancellationToken token);
		Task<PointShotModel[]> SearchPointsAsync(string search, RoutePoint? userCoordinates, CancellationToken token);

	}
}
