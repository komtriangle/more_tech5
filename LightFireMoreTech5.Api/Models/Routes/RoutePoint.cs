namespace LightFireMoreTech5.Models.Routes
{
	public class RoutePoint
	{
		/// <summary>
		/// Широта
		/// </summary>
		public double Latitude { get;set; }

		/// <summary>
		/// Долгота
		/// </summary>
		public double Longitude { get;set; }

		public RoutePoint() { }

		public RoutePoint(double latitude, double longitude) 
		{  
			Latitude = latitude; 
			Longitude = longitude;
		}
	}
}
