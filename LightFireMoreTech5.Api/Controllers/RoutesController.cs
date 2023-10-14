using LightFireMoreTech5.Models;
using LightFireMoreTech5.Models.Routes;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LightFireMoreTech5.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoutesController : Controller
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

		/// <summary>
		/// Построрение маршрута по отделния банка
		/// </summary>
		/// <param name="latitude">Широта пользователя</param>
		/// <param name="longitude">Долгота пользователя</param>
		/// <param name="officeId">Id отделения</param>
		/// <param name="type">Тип маршрута (пеший, авто)</param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpPost("CreateOfficeRoute")]
		[ProducesResponseType(typeof(Models.Routes.Route), StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateOfficeRoute(double latitude, double longitude,
			long officeId, RouteType type, CancellationToken token)
		{
			try
			{
				OfficeModel? office = await _pointService.GetOfficeByIdAsync(officeId, token);

				if (office == null)
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

		/// <summary>
		///  Построрение маршрута по банкомата банка
		/// </summary>
		/// <param name="latitude">Широта пользователя</param>
		/// <param name="longitude">Долгота пользователя</param>
		/// <param name="atmId">Id анкомата</param>
		/// <param name="type">Тип маршрута (пеший, авто)</param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpPost("CreateAtmRoute")]
		[ProducesResponseType(typeof(Models.Routes.Route), StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateAtmRoute(double latitude, double longitude,
			long atmId, RouteType type, CancellationToken token)
		{
			try
			{
				AtmModel? atm = await _pointService.GetAtmByIdAsync(atmId, token);

				if (atm == null)
				{
					return BadRequest($"Офис с Id: {atmId} не найден");
				}

				var start = new RoutePoint(latitude, longitude);
				var finish = new RoutePoint(atm.Latitude, atm.Longitude);

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
