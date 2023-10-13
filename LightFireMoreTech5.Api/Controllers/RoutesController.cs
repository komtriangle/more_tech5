using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Models;
using LightFireMoreTech5.Models.Routes;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace LightFireMoreTech5.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoutesController: Controller
	{
		private readonly IPointService _pointService;
		private readonly IPathService _pathService;

		public RoutesController(
			IPointService pointService, 
			IPathService pathService)
		{
			_pointService = pointService ??
				throw new ArgumentNullException(nameof(pointService));

			_pathService = pathService ??
				throw new ArgumentNullException(nameof(pathService)); ;
		}

		[HttpPost("CreateOfficeRoute")]
		public async Task<IActionResult> CreateOfficeRoute(double latitude, double longitude, 
			long officeId, RouteType type, CancellationToken token)
		{
			try
			{
				OfficeModel? office = await _pointService.GetOfficeByIdAsync(officeId, token);

				if(office == null)
				{
					return BadRequest($"Офис с Id: {officeId} не найден");
				}

				var start = new RoutePoint(latitude, longitude);
				var finish = new RoutePoint(office.Latitude, office.Longitude);

				var route = await _pathService.GetRouteAsync(start, finish, type, token);

				return Ok(route);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

	}
}
