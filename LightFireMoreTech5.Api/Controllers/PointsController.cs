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

		[HttpGet("Office")]
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
		[HttpGet("Office/{officeId}/ServiceWorkload/{serviceId}")]
		public async Task<ActionResult> GetOfficeServiceWorkload(long officeId, long serviceId, CancellationToken token)
		{
			try
			{
				var time = await _pointService.GetOfficeServiceWorkload(officeId, serviceId, token);

				return Ok(time);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("Atm")]
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

		[HttpPost("FindPoints")]
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
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
