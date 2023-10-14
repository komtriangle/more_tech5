using LightFireMoreTech5.Data.Entities;

namespace LightFireMoreTech5.Models
{
	public class OfficeModel
	{
		/// <summary>
		/// Идентификатор отделения
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// Широта
		/// </summary>
		public double Latitude { get; set; }
		/// <summary>
		/// Долгота
		/// </summary>
		public double Longitude { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		/// <summary>
		/// Станция метро, на которой располагается отделение
		/// </summary>
		public string MetroStation { get; set; }

		/// <summary>
		/// Есть ли в отделении РКО (Расчетно-кассовое обслуживание)
		/// </summary>
		public bool? Rko { get; set; }

		/// <summary>
		/// Есть ли в отделении пандус
		/// </summary>
		public bool? HasRamp { get; set; }
		/// <summary>
		/// Есть ли в отделении КЭП (Квалифицированная электронная подпись)
		/// </summary>
		public bool? Kep { get; set; }
		public bool? MyOffice { get; set; }
		/// <summary>
		/// Открытый тип офиса
		/// </summary>
		public string OfficeType { get; set; }

		/// <summary>
		/// Формат ТП
		/// </summary>
		public string SalePointFormat { get; set; }

		/// <summary>
		/// Расписание для физ лиц
		/// </summary>
		public virtual OfficeScheduleModel IndividualSchedule { get; set; }

		/// <summary>
		/// Расписание для юр лиц
		/// </summary>
		public virtual OfficeScheduleModel LegalEntitySchedule { get; set; }

		public OfficeModel() { }

		public OfficeModel(Office dbOffice)
		{
			Id = dbOffice.Id;
			Latitude = dbOffice.Location.Coordinate.X;
			Longitude = dbOffice.Location.Coordinate.Y;
			Name = dbOffice.Name;
			Address = dbOffice.Address;
			HasRamp = dbOffice.HasRamp;
			Kep = dbOffice.Kep;
			MetroStation = dbOffice.MetroStation;
			MyOffice = dbOffice.MyOffice;
			OfficeType = dbOffice.OfficeType;
			Rko = dbOffice.Rko;
			SalePointFormat = dbOffice.SalePointFormat;
			IndividualSchedule = new OfficeScheduleModel()
			{
				MondayStart = dbOffice.IndividualSchedule.MondayStart,
				MondayEnd = dbOffice.IndividualSchedule.MondayEnd,
				TuesdayStart = dbOffice.IndividualSchedule.TuesdayStart,
				TuesdayEnd = dbOffice.IndividualSchedule.TuesdayEnd,
				WednesdayStart = dbOffice.IndividualSchedule.WednesdayStart,
				WednesdayEnd = dbOffice.IndividualSchedule.WednesdayEnd,
				ThursdayStart = dbOffice.IndividualSchedule.ThursdayStart,
				ThursdayEnd = dbOffice.IndividualSchedule.ThursdayEnd,
				FridayStart = dbOffice.IndividualSchedule.FridayStart,
				FridayEnd = dbOffice.IndividualSchedule.FridayEnd,
				SaturdayStart = dbOffice.IndividualSchedule.SaturdayStart,
				SaturdayEnd = dbOffice.IndividualSchedule.SaturdayEnd,
				SundayStart = dbOffice.IndividualSchedule.SundayStart,
				SundayEnd = dbOffice.IndividualSchedule.SundayEnd,
			};
			LegalEntitySchedule = new OfficeScheduleModel()
			{
				MondayStart = dbOffice.LegalEntitySchedule.MondayStart,
				MondayEnd = dbOffice.LegalEntitySchedule.MondayEnd,
				TuesdayStart = dbOffice.LegalEntitySchedule.TuesdayStart,
				TuesdayEnd = dbOffice.LegalEntitySchedule.TuesdayEnd,
				WednesdayStart = dbOffice.LegalEntitySchedule.WednesdayStart,
				WednesdayEnd = dbOffice.LegalEntitySchedule.WednesdayEnd,
				ThursdayStart = dbOffice.LegalEntitySchedule.ThursdayStart,
				ThursdayEnd = dbOffice.LegalEntitySchedule.ThursdayEnd,
				FridayStart = dbOffice.LegalEntitySchedule.FridayStart,
				FridayEnd = dbOffice.LegalEntitySchedule.FridayEnd,
				SaturdayStart = dbOffice.LegalEntitySchedule.SaturdayStart,
				SaturdayEnd = dbOffice.LegalEntitySchedule.SaturdayEnd,
				SundayStart = dbOffice.LegalEntitySchedule.SundayStart,
				SundayEnd = dbOffice.LegalEntitySchedule.SundayEnd,
			};
		}
	}
}
