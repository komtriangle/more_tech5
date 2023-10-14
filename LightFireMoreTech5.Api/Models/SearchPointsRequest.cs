using LightFireMoreTech5.Models.Routes;

namespace LightFireMoreTech5.Models
{
	public class SearchPointsRequest
	{
		/// <summary>
		/// Строка поиска
		/// </summary>
		public string Search { get; set; }

		/// <summary>
		/// Координаты пользователя (optional)
		/// </summary>
		public RoutePoint? UserCoordinates { get; set; }
	}
}
