namespace LightFireMoreTech5.Models.Routes
{
	public class Route
	{
		/// <summary>
		/// Тип маршрута
		/// </summary>
		public RouteType Type { get; set; }

		/// <summary>
		/// Длина маршрута в метрах
		/// </summary>
		public double DistanceMetres { get;set; }

		/// <summary>
		/// Время, которое займет маршрут в секундах
		/// </summary>
		public int TimeSeconds { get; set; }

		/// <summary>
		/// Точки маршрута
		/// </summary>
		public RoutePoint[] Points { get; set; }
	}
}
