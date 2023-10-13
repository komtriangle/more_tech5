using LightFileMoreTech5.Configuration;
using LightFireMoreTech5.Models.Routes;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace LightFireMoreTech5.Services
{
	public class PathService : IPathService
	{
		private readonly GraphHopperConfiguration _graphHopperConfiguration;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<PathService> _logger;

		public PathService
			(IOptions<GraphHopperConfiguration> configuration,
			IHttpClientFactory httpClientFactory,
			ILogger<PathService> logger)
		{
			_graphHopperConfiguration = configuration.Value ??
				throw new ArgumentNullException(nameof(GraphHopperConfiguration));

			_httpClientFactory = httpClientFactory ??
				throw new ArgumentNullException(nameof(httpClientFactory));

			_logger = logger ??
				throw new ArgumentNullException(nameof(logger));
		}

		public async Task<Models.Routes.Route> GetRouteAsync(RoutePoint start, RoutePoint finish, RouteType type, CancellationToken token)
		{
			try
			{
				using (var httpClient = _httpClientFactory.CreateClient("graphHopper"))
				{
					GraphHopperRouteRequestBody requestBody = new GraphHopperRouteRequestBody(start, finish, type);

					string jsonBody = JsonConvert.SerializeObject(requestBody);

					StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

					HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{_graphHopperConfiguration.GetRouteUrl}?" +
						$"key={_graphHopperConfiguration.ApiKey}", content, token);

					if (!httpResponseMessage.IsSuccessStatusCode)
					{
						throw new Exception($"Неудачный запрос в graphHopper. Статус-код: {httpResponseMessage.StatusCode}");
					}

					string response = await httpResponseMessage.Content.ReadAsStringAsync();

					GraphHopperRouteResponse graphHopperRouteResponse = JsonConvert.DeserializeObject<GraphHopperRouteResponse>(response);

					if (graphHopperRouteResponse == null || graphHopperRouteResponse.Paths == null ||
						!graphHopperRouteResponse.Paths.Any())
						throw new Exception("Не удалось распарсить ответ от graphHopper");

					Models.Routes.Route result = new Models.Routes.Route()
					{
						Type = type,
						Points = graphHopperRouteResponse.Paths.FirstOrDefault().Points.Coordinates
							.Select(x => new RoutePoint()
							{
								Latitude = x[0],
								Longitude = x[1]
							})
							.ToArray()
					};

					return result;

				}
			}
			catch (Exception ex)
			{
				string message = "Ошибка при построении маршрута";
				_logger.LogError(ex, message);

				throw new Exception(message);
			}
		}
	}
}
