using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LightFireMoreTech5.Models
{
	public class AtmModel
	{
		/// <summary>
		/// Идентификатор банкомата
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Работает ли круглочуточно
		/// </summary>
		public bool AllDay { get; set; }

		/// <summary>
		/// Адрес
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Широта
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// Долгота
		/// </summary>
		public double Longitude { get; set; }

		/// <summary>
		/// Есть ли инвалидная коляска
		/// </summary>
		public ServiceCapability WheelChairCapability { get; set; }

		/// <summary>
		/// Доступна ли сейчас инвалидная коляска
		/// </summary>
		public ServiceActivity WheelChairActivity { get; set; }

		/// <summary>
		/// Есть ли поддержка банкомата для слепых
		/// </summary>
		public ServiceCapability BlindCapability { get; set; }

		/// <summary>
		/// Работает ли сейчас функция для слепых
		/// </summary>
		public ServiceActivity BlindChairActivity { get; set; }

		/// <summary>
		/// Есть ли поддержка Nfc
		/// </summary>
		public ServiceCapability NfcBankCardsCapability { get; set; }

		/// <summary>
		/// Работает ли сейчас поддержка Nfc
		/// </summary>
		public ServiceActivity NfcBankCardsActivity { get; set; }

		/// <summary>
		/// Есть ли фукнция чтения Qr
		/// </summary>
		public ServiceCapability QrReadCapability { get; set; }

		/// <summary>
		/// Работает ли сейчас чтение Qr
		/// </summary>
		public ServiceActivity QrReadActivity { get; set; }

		/// <summary>
		/// Есть ли поддержка валюты USD
		/// </summary>
		public ServiceCapability SupportUsdCapability { get; set; }

		/// <summary>
		/// Работает ли сейчас поддержка валюты USD
		/// </summary>
		public ServiceActivity SupportUsdActivity { get; set; }

		public ServiceCapability SupportChargeRubCapability { get; set; }
		public ServiceActivity SupportChargeRubActivity { get; set; }

		/// <summary>
		/// Есть ли поддержка валюты EUR
		/// </summary>
		public ServiceCapability SupportEurCapability { get; set; }

		/// <summary>
		/// Работает ли сейчас поддержка валюты EUR
		/// </summary>
		public ServiceActivity SupportEurActivity { get; set; }

		/// <summary>
		/// Есть ли поддержка валюты RUB
		/// </summary>
		public ServiceCapability SupportRubCapability { get; set; }

		/// <summary>
		/// Работает ли сейчас поддержка валюты RUB
		/// </summary>
		public ServiceActivity SupportRubActivity { get; set; }

		public AtmModel() { }
		public AtmModel(Atm dbAtm)
		{
			Id = dbAtm.Id;
			Address = dbAtm.Address;
			Latitude = dbAtm.Location.Coordinate.X;
			Longitude = dbAtm.Location.Coordinate.Y;
			WheelChairCapability = dbAtm.WheelChairCapability;
			WheelChairActivity = dbAtm.WheelChairActivity;
			BlindCapability = dbAtm.BlindCapability;
			BlindChairActivity = dbAtm.BlindChairActivity;
			NfcBankCardsCapability = dbAtm.NfcBankCardsCapability;
			NfcBankCardsActivity = dbAtm.NfcBankCardsActivity;
			QrReadCapability = dbAtm.QrReadCapability;
			QrReadActivity = dbAtm.QrReadActivity;
			SupportUsdCapability = dbAtm.SupportUsdCapability;
			SupportUsdActivity = dbAtm.SupportUsdActivity;
			SupportChargeRubCapability = dbAtm.SupportChargeRubCapability;
			SupportChargeRubActivity = dbAtm.SupportChargeRubActivity;
			SupportEurCapability = dbAtm.SupportEurCapability;
			SupportEurActivity = dbAtm.SupportEurActivity;
			SupportRubCapability = dbAtm.SupportRubCapability;
			SupportRubActivity = dbAtm.SupportRubActivity;
		}
	}
}
