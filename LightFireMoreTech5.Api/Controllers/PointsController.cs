using LightFireMoreTech5.Models;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LightFireMoreTech5.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PointsController: Controller
	{
		private readonly IPointService _pointService;

		public PointsController(
			IPointService pointService)
		{
			_pointService = pointService;
		}

		[HttpGet("GetOffice")]
		public async Task<ActionResult> GetOffice(long id, CancellationToken token)
		{
			try
			{
				var office = await _pointService.GetOfficeByIdAsync(id, token);

				if(office == null)
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

		[HttpPost("FindPoints")]
		public async Task<ActionResult> FindPoints([FromBody] FindPointModel request, CancellationToken token)
		{
			try
			{
				var points = await _pointService.GetPointsInRadiusAsync(request.Latitude, request.Longitude, request.Radius, token);

				return Ok(points);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
