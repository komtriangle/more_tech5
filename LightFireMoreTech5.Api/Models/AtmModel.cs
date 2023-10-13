using LightFireMoreTech5.Data.Enums;

namespace LightFireMoreTech5.Models
{
	public class AtmModel
	{
		public long Id { get; set; }
		public bool AllDay { get; set; }
		public string Address { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public ServiceCapability WheelChairCapability { get; set; }
		public ServiceActivity WheelChairActivity { get; set; }

		public ServiceCapability BlindCapability { get; set; }
		public ServiceActivity BlindChairActivity { get; set; }

		public ServiceCapability NfcBankCardsCapability { get; set; }
		public ServiceActivity NfcBankCardsActivity { get; set; }

		public ServiceCapability QrReadCapability { get; set; }
		public ServiceActivity QrReadActivity { get; set; }

		public ServiceCapability SupportUsdCapability { get; set; }
		public ServiceActivity SupportUsdActivity { get; set; }

		public ServiceCapability SupportChargeRubCapability { get; set; }
		public ServiceActivity SupportChargeRubActivity { get; set; }

		public ServiceCapability SupportEurCapability { get; set; }
		public ServiceActivity SupportEurActivity { get; set; }

		public ServiceCapability SupportRubCapability { get; set; }
		public ServiceActivity SupportRubActivity { get; set; }
	}
}
