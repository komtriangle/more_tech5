using NetTopologySuite.Geometries;

namespace LightFireMoreTech5.Data.Entities
{
	public class Office
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string MetroStation { get; set; }
		public bool? AllDay { get; set; }
		public bool? Rko { get; set; }
		public bool? HasRamp { get; set; }
		public bool? Kep { get; set; }
		public bool? MyOffice { get; set; }
		public string OfficeType { get; set; }
		public string SalePointFormat { get; set; }
		public Point Location { get; set; }

		public long IndividualShceduleId { get; set; }
		public long LegalEntityShceduleId { get; set; }
		public int WorkLoad { get; set; }
		public virtual OfficeSchedule IndividualSchedule { get; set; }
		public virtual OfficeSchedule LegalEntitySchedule { get; set; }
		public List<OfficeService> OfficeServices { get; set; }
		public List<Window> Windows { get; set; }
	}
}
