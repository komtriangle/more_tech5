
﻿using LightFireMoreTech5.Api.Models.Requests;
using LightFireMoreTech5.Models;
using LightFireMoreTech5.Models.Enums;
using LightFireMoreTech5.Models.Routes;

namespace LightFireMoreTech5.Services.Interfaces
{
	public interface IPointService
	{
		Task<OfficeModel?> GetOfficeByIdAsync(long id, CancellationToken token);

		Task<AtmModel?> GetAtmByIdAsync(long id, CancellationToken token);
		Task<PointsInRadiusModel> GetPointsInRadiusAsync(double latitude, double longitude, double radius, ClientType? type, List<long> serviceIds, CancellationToken token);
		Task UpdateOfficeWorkloadAsync(UpdateOfficeWorkloadRequest request, CancellationToken token);
		Task<int> GetOfficeServiceWorkload(long officeId, long serviceId, CancellationToken token);
		Task<PointShotModel[]> SearchPointsAsync(string search, RoutePoint? userCoordinates, CancellationToken token);
		Task TakeTicket(TakeTicketRequest request, CancellationToken token);
	}
}
