using LightFireMoreTech5.Data;
using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.Enums;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite.Noding;
using Newtonsoft.Json;
using System.Drawing;
using Point = NetTopologySuite.Geometries.Point;

namespace ParseSourceData
{
	internal class Program
	{
		public class OpenHour
		{
			public string days { get; set; }
			public string hours { get; set; }
		}

		public class SalePoint
		{
			public string salePointName { get; set; }
			public string address { get; set; }
			public string status { get; set; }
			public List<OpenHour> openHours { get; set; }
			public string rko { get; set; }
			public List<OpenHour> openHoursIndividual { get; set; }
			public string officeType { get; set; }
			public string salePointFormat { get; set; }
			public string? suoAvailability { get; set; }
			public string? hasRamp { get; set; }
			public double latitude { get; set; }
			public double longitude { get; set; }
			public string metroStation { get; set; }
			public int? distance { get; set; }
			public bool? kep { get; set; }
			public bool? myBranch { get; set; }
		}

		public class Service
		{
			public string serviceCapability { get; set; }
			public string serviceActivity { get; set; }
		}

		public class Services
		{
			public Service wheelchair { get; set; }
			public Service blind { get; set; }
			public Service nfcForBankCards { get; set; }
			public Service qrRead { get; set; }
			public Service supportsUsd { get; set; }
			public Service supportsChargeRub { get; set; }
			public Service supportsEur { get; set; }
			public Service supportsRub { get; set; }
		}

		public class AtmModel
		{
			public string address { get; set; }
			public double latitude { get; set; }
			public double longitude { get; set; }
			public bool allDay { get; set; }
			public Dictionary<string, Service> services { get; set; }

		}


		static void Main(string[] args)
		{
			FillAtm();
		}

		private static void FillAtm()
		{
			string connectionString = "Host=193.104.57.178;port=5432;user id=lightFire;password=pass;database=postgres";

			DbContextOptionsBuilder<BankServicesContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<BankServicesContext>();

			dbContextOptionsBuilder.UseNpgsql(connectionString, x => x.UseNetTopologySuite()).UseLowerCaseNamingConvention();

			//var context = new BankServicesContext(dbContextOptionsBuilder.Options);

			string json = File.ReadAllText(@"C:\Users\komda\Downloads\Data\atms.txt");

			List<AtmModel> locations = JsonConvert.DeserializeObject<List<AtmModel>>(json);

			foreach (AtmModel atm in locations)
			{
				var dbAtm = new Atm();
				dbAtm.AllDay = atm.allDay;
				dbAtm.Location = new NetTopologySuite.Geometries.Point(
					new Coordinate(atm.latitude, atm.longitude))
				{ SRID = 4326 };
				dbAtm.Address = atm.address;

				foreach(var service in atm.services)
				{
					ServiceCapability serviceCapability = service.Value.serviceCapability switch
					{
						"UNSUPPORTED" => ServiceCapability.Unsupported,
						"UNKNOWN" => ServiceCapability.Unknown,
						"SUPPORTED" => ServiceCapability.Supported
					};

					ServiceActivity serviceActivity = service.Value.serviceActivity switch
					{
						"UNAVAILABLE" => ServiceActivity.UnAvailable,
						"UNKNOWN" => ServiceActivity.Unknown,
						"AVAILABLE" => ServiceActivity.Available
					};

					switch (service.Key)
					{
						case nameof(Services.wheelchair):
							dbAtm.WheelChairActivity = serviceActivity;
							dbAtm.WheelChairCapability = serviceCapability;
							break;
						case nameof(Services.blind):
							dbAtm.BlindChairActivity = serviceActivity;
							dbAtm.BlindCapability = serviceCapability;
							break;
						case nameof(Services.nfcForBankCards):
							dbAtm.NfcBankCardsActivity = serviceActivity;
							dbAtm.NfcBankCardsCapability = serviceCapability;
							break;
						case nameof(Services.qrRead):
							dbAtm.QrReadActivity = serviceActivity;
							dbAtm.QrReadCapability = serviceCapability;
							break;
						case nameof(Services.supportsUsd):
							dbAtm.SupportUsdActivity = serviceActivity;
							dbAtm.SupportUsdCapability = serviceCapability;
							break;
						case nameof(Services.supportsRub):
							dbAtm.SupportRubActivity = serviceActivity;
							dbAtm.SupportRubCapability = serviceCapability;
							break;
						case nameof(Services.supportsEur):
							dbAtm.SupportEurActivity = serviceActivity;
							dbAtm.SupportEurCapability = serviceCapability;
							break;
						case nameof(Services.supportsChargeRub):
							dbAtm.SupportChargeRubActivity = serviceActivity;
							dbAtm.SupportChargeRubCapability = serviceCapability;
							break;
					}
				}

                Console.WriteLine(atm);


            }
		}

		private static void FillOffices()
		{
			string connectionString = "Host=193.104.57.178;port=5432;user id=lightFire;password=pass;database=postgres";

			DbContextOptionsBuilder<BankServicesContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<BankServicesContext>();

			dbContextOptionsBuilder.UseNpgsql(connectionString, x => x.UseNetTopologySuite()).UseLowerCaseNamingConvention();

			var context = new BankServicesContext(dbContextOptionsBuilder.Options);

			string json = File.ReadAllText(@"C:\Users\komda\Downloads\Data\offices.txt");

			List<SalePoint> salePoints = JsonConvert.DeserializeObject<List<SalePoint>>(json);

			foreach (SalePoint point in salePoints)
			{
				Office office = new Office();
				office.Name = point.salePointName;
				office.Address = point.address;
				office.MetroStation = point.metroStation;
				office.Rko = point.rko == "есть РКО" ? true : false;
				office.HasRamp = point.hasRamp == "Y" ? true : false;
				office.MyOffice = point.myBranch;
				office.Kep = point.kep;
				office.OfficeType = point.officeType;
				office.SalePointFormat = point.salePointFormat;
				office.Location = new Point(
					new Coordinate(point.latitude, point.longitude))
				{ SRID = 4326 };

				var legalSchedule = new OfficeSchedule() { };

				foreach (OpenHour openHour in point.openHours)
				{
					if (openHour.days?.Length == 2)
					{
						TimeOnly? start = null;
						TimeOnly? end = null;


						if (openHour.hours != "выходной")
						{
							start = TimeOnly.Parse(openHour.hours.Split('-')[0]);
							end = TimeOnly.Parse(openHour.hours.Split('-')[1]);
						}

						switch (openHour.days)
						{

							case "пн":
								legalSchedule.MondayStart = start;
								legalSchedule.MondayEnd = end;
								break;
							case "вт":
								legalSchedule.TuesdayStart = start;
								legalSchedule.TuesdayEnd = end;
								break;
							case "ср":
								legalSchedule.WednesdayStart = start;
								legalSchedule.WednesdayEnd = end;
								break;
							case "чт":
								legalSchedule.ThursdayStart = start;
								legalSchedule.ThursdayEnd = end;
								break;
							case "пт":
								legalSchedule.FridayStart = start;
								legalSchedule.FridayEnd = end;
								break;
							case "сб":
								legalSchedule.SaturdayStart = start;
								legalSchedule.SaturdayEnd = end;
								break;
							case "вс":
								legalSchedule.SundayStart = start;
								legalSchedule.SundayEnd = end;
								break;


						}
					}
					else if (openHour.hours == "пн-пт")
					{
						TimeOnly? start = null;
						TimeOnly? end = null;


						if (openHour.hours != "выходной")
						{
							start = TimeOnly.Parse(openHour.hours.Split('-')[0]);
							end = TimeOnly.Parse(openHour.hours.Split('-')[1]);
						}

						legalSchedule.MondayStart = start;
						legalSchedule.MondayEnd = end;

						legalSchedule.TuesdayStart = start;
						legalSchedule.TuesdayEnd = end;

						legalSchedule.WednesdayStart = start;
						legalSchedule.WednesdayEnd = end;

						legalSchedule.ThursdayStart = start;
						legalSchedule.ThursdayEnd = end;

						legalSchedule.FridayStart = start;
						legalSchedule.FridayEnd = end;
					}
				}

				var individualSchedule = new OfficeSchedule() { };

				foreach (OpenHour openHour in point.openHoursIndividual)
				{
					if (openHour.days?.Length == 2)
					{
						TimeOnly? start = null;
						TimeOnly? end = null;


						if (openHour.hours != "выходной")
						{
							start = TimeOnly.Parse(openHour.hours.Split('-')[0]);
							end = TimeOnly.Parse(openHour.hours.Split('-')[1]);
						}

						switch (openHour.days)
						{

							case "пн":
								individualSchedule.MondayStart = start;
								individualSchedule.MondayEnd = end;
								break;
							case "вт":
								individualSchedule.TuesdayStart = start;
								individualSchedule.TuesdayEnd = end;
								break;
							case "ср":
								individualSchedule.WednesdayStart = start;
								individualSchedule.WednesdayEnd = end;
								break;
							case "чт":
								individualSchedule.ThursdayStart = start;
								individualSchedule.ThursdayEnd = end;
								break;
							case "пт":
								individualSchedule.FridayStart = start;
								individualSchedule.FridayEnd = end;
								break;
							case "сб":
								individualSchedule.SaturdayStart = start;
								individualSchedule.SaturdayEnd = end;
								break;
							case "вс":
								individualSchedule.SundayStart = start;
								individualSchedule.SundayEnd = end;
								break;


						}
					}
					else if (openHour.hours == "пн-пт")
					{
						TimeOnly? start = null;
						TimeOnly? end = null;


						if (openHour.hours != "выходной")
						{
							start = TimeOnly.Parse(openHour.hours.Split('-')[0]);
							end = TimeOnly.Parse(openHour.hours.Split('-')[1]);
						}

						individualSchedule.MondayStart = start;
						individualSchedule.MondayEnd = end;

						individualSchedule.TuesdayStart = start;
						individualSchedule.TuesdayEnd = end;

						individualSchedule.WednesdayStart = start;
						individualSchedule.WednesdayEnd = end;

						individualSchedule.ThursdayStart = start;
						individualSchedule.ThursdayEnd = end;

						individualSchedule.FridayStart = start;
						individualSchedule.FridayEnd = end;
					}
				}

				context.OfficeSchedules.Add(individualSchedule);
				context.OfficeSchedules.Add(legalSchedule);

				office.LegalEntitySchedule = legalSchedule;
				office.IndividualSchedule = individualSchedule;

				context.Offices.Add(office);
				context.SaveChanges();
			}
		}
	}
}