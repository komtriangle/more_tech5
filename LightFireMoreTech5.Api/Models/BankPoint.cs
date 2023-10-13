using LightFireMoreTech5.Models.Enums;
using NetTopologySuite.Geometries;

namespace LightFireMoreTech5.Models
{
	public class BankPoint
	{
		public long Id { get; set; }
		public PointType Type { get; set; }

		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
