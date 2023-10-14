using LightFireMoreTech5.Models;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LightFireMoreTech5.Api.Services.Interfaces;
using LightFireMoreTech5.Data.Enums;

namespace LightFireMoreTech5.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;

		public ServiceController(
			IServiceService servicService)
		{
			_serviceService = servicService;
		}

		[HttpGet("Services")]
		public async Task<ActionResult> GetServices([FromQuery(Name = "Type")] ServiceType ServiceType, CancellationToken token)
		{
			try
			{
				var services = await _serviceService.GetServicesAsync(ServiceType, token);

				if (services == null)
				{
					return NotFound("Сервисы не найден");
				}

				return Ok(services);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}