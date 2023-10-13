namespace LightFireMoreTech5.Data.Entities
{
	public class OfficeSchedule
	{
		public long Id { get; set; }

		public TimeOnly? MondayStart { get; set; }
		public TimeOnly? MondayEnd { get; set; }

		public TimeOnly? TuesdayStart { get; set; }
		public TimeOnly? TuesdayEnd { get; set; }

		public TimeOnly? WednesdayStart { get; set; }
		public TimeOnly? WednesdayEnd { get; set; }

		public TimeOnly? ThursdayStart { get; set; }
		public TimeOnly? ThursdayEnd { get; set; }

		public TimeOnly? FridayStart { get; set; }
		public TimeOnly? FridayEnd { get; set; }

		public TimeOnly? SaturdayStart { get; set; }
		public TimeOnly? SaturdayEnd { get; set; }

		public TimeOnly? SundayStart { get; set; }
		public TimeOnly? SundayEnd { get; set; }

		public virtual ICollection<Office> IndividualOffices { get; set; }
		public virtual ICollection<Office> LegalEntitiesOffices { get; set; }

		public OfficeSchedule()
		{
			IndividualOffices = new HashSet<Office>();
			LegalEntitiesOffices = new HashSet<Office>();
		}
	}

}
