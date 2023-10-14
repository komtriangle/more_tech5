namespace LightFireMoreTech5.Models.Routes
{
	public class GraphHopperRouteResponse
	{
		public ResponsePath[] Paths { get; set; }
	}

	public class ResponsePath
	{
		public double Distance { get;set; }
		public int Time { get; set; }
		public ResponsePoints Points { get; set; }
	}

	public class ResponsePoints
	{
		public double[][] Coordinates { get; set; }
	}
}
