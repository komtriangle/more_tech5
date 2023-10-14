using LightFireMoreTech5.Api.Models.Requests;
using LightFireMoreTech5.Models;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LightFireMoreTech5.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PointsController : Controller
	{
		private readonly IPointService _pointService;

		public PointsController(
			IPointService pointService)
		{
			_pointService = pointService;
		}

		/// <summary>
		/// Получение информации об отделения банка по Id
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpGet("Office")]
		[ProducesResponseType(typeof(OfficeModel), StatusCodes.Status200OK)]
		public async Task<ActionResult> GetOffice(long id, CancellationToken token)
		{
			try
			{
				var office = await _pointService.GetOfficeByIdAsync(id, token);

				if (office == null)
				{
					return NotFound("Офис не найден");
				}

				return Ok(office);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		/// Получение информации о банкомате по Id
		/// </summary>
		/// <param name="id">Id отделения</param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpGet("Atm")]
		[ProducesResponseType(typeof(AtmModel), StatusCodes.Status200OK)]
		public async Task<ActionResult> GetAtm(long id, CancellationToken token)
		{
			try
			{
				var atm = await _pointService.GetAtmByIdAsync(id, token);

				if (atm == null)
				{
					return NotFound("Банкомат не найден");
				}

				return Ok(atm);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		/// Поиск отделений и банкоматов
		/// </summary>
		/// <param name="request"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpPost("FindPoints")]
		[ProducesResponseType(typeof(BankPoint[]), StatusCodes.Status200OK)]
		public async Task<ActionResult> FindPoints([FromBody] FindPointModel request, CancellationToken token)
		{
			try
			{
				var points = await _pointService.GetPointsInRadiusAsync(request.Latitude, request.Longitude, request.Radius, request.ServiceIds, token);

				return Ok(points);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Office/Workload")]
		public async Task<ActionResult> UpdateOfficeWorkload([FromBody] UpdateOfficeWorkloadRequest request, CancellationToken token)
		{
			try
			{
				await _pointService.UpdateOfficeWorkloadAsync(request, token);

				return Ok();

			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SearchPoints")]
		[ProducesResponseType(typeof(PointShotModel[]), StatusCodes.Status200OK)]
		public async Task<IActionResult> SearchPoints([FromBody] SearchPointsRequest request, CancellationToken token)
		{
			if (string.IsNullOrWhiteSpace(request.Search))
			{
				return BadRequest("Необходимо заполнить поле Search");
			}

			try
			{
				var points = await _pointService.SearchPointsAsync(request.Search, request.UserCoordinates, token);

				return Ok(points);
			}
	}
}
