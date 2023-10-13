using NetTopologySuite.Geometries;

namespace LightFireMoreTech5.Data.Entities
{
	public class Office
	{
		public long Id { get; set; }
		public Point Location { get; set; }
	}
}
