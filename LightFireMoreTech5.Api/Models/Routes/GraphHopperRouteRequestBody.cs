using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace LightFireMoreTech5.Models.Routes
{
	public class GraphHopperRouteRequestBody
	{
		[JsonProperty(PropertyName = "points")]
		public double[][] Points { get; set; }

		[JsonProperty(PropertyName = "profile")]
		public string Profile { get; set; }

		[JsonProperty(PropertyName = "locale")]
		public string Locale { get; set; }

		[JsonProperty(PropertyName = "calc_points")]
		public bool CalcPoints { get;set; }

		[JsonProperty(PropertyName = "instructions")]
		public bool Instructions { get; set; }

		[JsonProperty(PropertyName = "points_encoded")]
		public bool PointsEncoded { get; set; }

		public GraphHopperRouteRequestBody(RoutePoint start, RoutePoint finish, RouteType route)
		{
			if(start == null)
				throw new ArgumentNullException(nameof(start));

			if(finish == null)
				throw new ArgumentNullException(nameof(finish));

			Instructions = false;
			CalcPoints = true;
			PointsEncoded = false;
			Locale = "en";
			Points = new double[][] {
				new double[]
				{
					start.Latitude,
					start.Longitude
				},
				new double[]
				{
					finish.Latitude,
					finish.Longitude
				}
			};
			Profile = ConvertRouteType(route);
		}

		private string ConvertRouteType(RouteType routeType)
		{
			switch(routeType)
			{
				case RouteType.Foot:
					return "foot";
				case RouteType.Car:
					return "car";
				default:
					throw new Exception($"Unsupported routeType: {routeType}");
			}
		}

	}
}
