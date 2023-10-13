namespace LightFireMoreTech5.Models.Routes
{
	public class RoutePoint
	{
		public double Latitude { get;set; }
		public double Longitude { get;set; }

		public RoutePoint() { }

		public RoutePoint(double latitude, double longitude) 
		{  
			Latitude = latitude; 
			Longitude = longitude;
		}
	}
}
