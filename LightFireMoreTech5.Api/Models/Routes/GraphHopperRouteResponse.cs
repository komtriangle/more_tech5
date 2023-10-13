namespace LightFireMoreTech5.Models.Routes
{
	public class GraphHopperRouteResponse
	{
		public ResponsePath[] Paths { get; set; }
	}

	public class ResponsePath
	{
		public ResponsePoints Points { get; set; }
	}

	public class ResponsePoints
	{
		public double[][] Coordinates { get; set; }
	}
}
