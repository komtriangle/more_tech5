using LightFireMoreTech5.Data.Entities;

namespace LightFireMoreTech5.Models
{
	public class OfficeModel
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
		public virtual OfficeScheduleModel IndividualSchedule { get; set; }
		public virtual OfficeScheduleModel LegalEntitySchedule { get; set; }
	}
}
