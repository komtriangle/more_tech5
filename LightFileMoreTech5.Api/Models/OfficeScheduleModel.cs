namespace LightFireMoreTech5.Models
{
	public class OfficeScheduleModel
	{
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
	}
}
