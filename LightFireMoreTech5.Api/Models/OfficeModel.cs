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
	}
}
