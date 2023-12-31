using LightFireMoreTech5.Api.Models.Enums;
using LightFireMoreTech5.Api.Models.Enums;
using LightFireMoreTech5.Api.Models.Requests;
using LightFireMoreTech5.Data;
using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.Enums;
using LightFireMoreTech5.Models;
using LightFireMoreTech5.Models.Enums;
using LightFireMoreTech5.Models.Routes;
using LightFireMoreTech5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetTopologySuite.Geometries;
using Point = NetTopologySuite.Geometries.Point;

namespace LightFireMoreTech5.Services
{
	public class PointService : IPointService
	{
		private readonly IDbContextFactory<BankServicesContext> _dbContextFactory;
		private readonly ILogger<PointService> _logger;

		public PointService(
			IDbContextFactory<BankServicesContext> dbContextFactory,
			ILogger<PointService> logger)
		{
			_dbContextFactory = dbContextFactory ??
				throw new ArgumentNullException(nameof(dbContextFactory));

			_logger = logger ??
				throw new ArgumentNullException(nameof(logger));
		}

		public async Task<AtmModel?> GetAtmByIdAsync(long id, CancellationToken token)
		{
			try
			{
				using (var context = await _dbContextFactory.CreateDbContextAsync())
				{
					var dbAtm = await context.Atms.FindAsync(id, token);

					if (dbAtm == null)
					{
						return null;
					}

					return new AtmModel(dbAtm);

				}

			}
			catch (Exception ex)
			{
				string message = "Ошибка во время получения банкомата";
				_logger.LogError(ex, message);
				throw new Exception(message);
			}
		}

		public async Task<OfficeModel?> GetOfficeByIdAsync(long id, CancellationToken token)
		{
			try
			{
				using (var context = await _dbContextFactory.CreateDbContextAsync())
				{
					var dbOffice = await context.Offices
					.Include(x => x.IndividualSchedule)
					.Include(x => x.LegalEntitySchedule)
					.FirstOrDefaultAsync(x => x.Id == id, token);

					if (dbOffice == null)
					{
						return null;
					}
					return new OfficeModel()
					{
						Id = id,
						Latitude = dbOffice.Location.Coordinate.X,
						Longitude = dbOffice.Location.Coordinate.Y,
						Name = dbOffice.Name,
						//AllDay = dbOffice.AllDay,
						Address = dbOffice.Address,
						HasRamp = dbOffice.HasRamp,
						Kep = dbOffice.Kep,
						MetroStation = dbOffice.MetroStation,
						MyOffice = dbOffice.MyOffice,
						OfficeType = dbOffice.OfficeType,
						Rko = dbOffice.Rko,
						SalePointFormat = dbOffice.SalePointFormat,
						WorkLoad = dbOffice.WorkLoad,
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
						},
						LegalEntitySchedule = new OfficeScheduleModel()

					};
					return new OfficeModel(dbOffice);
				}
			}
			catch (Exception ex)
			{
				string message = "Ошибка во время получения офиса";
				_logger.LogError(ex, message);
				throw new Exception(message);
			}
		}
		public async Task<int> GetOfficeServiceWorkload(long officeId, long serviceId, CancellationToken token)
		{
			try
			{
				using var context = await _dbContextFactory.CreateDbContextAsync();
				// получаем все окна отделения для нашей операции
				var office = await context.Offices
				.Where(x => x.Id == officeId)
				.Include(x => x.Windows)
					.ThenInclude(w => w.WindowServices)
						.ThenInclude(ws => ws.Service)
				.FirstOrDefaultAsync();

					if (office == null)
						return -1;

					var avaliableWindows = office.Windows.Where(x => x.WindowServices.Any(ws => ws.Service.Id == serviceId));

					// возвращаем среднее значение в минутах
					var averageTime = (int)Math.Round(avaliableWindows.Average(w => w.BusyTime));

					return averageTime;
			}
			catch (Exception ex)
			{
				string message = "Ошибка во время получения точек";
				_logger.LogError(ex, message);
				throw new Exception(message);
			}
		}

		public async Task<PointsInRadiusModel> GetPointsInRadiusAsync(double latitude, double longitude, double radius, ClientType? type, List<long> serviceIds, CancellationToken token)
		{
			radius = Math.Min(radius, 5000);

			try
			{
				OfficeModel[] offices = Array.Empty<OfficeModel>();
				AtmModel[] atms = Array.Empty<AtmModel>();

				ServiceType? serviceType = type switch
				{
					ClientType.Atm => ServiceType.Both,
					ClientType.Individual => ServiceType.Physical,
					ClientType.LegalEnity => ServiceType.Legal,
					_ => null
				};
				
				if (type == ClientType.Atm)
				{
					atms = await FindAtmsAsync(latitude, longitude, radius,  serviceType, serviceIds, token);
				}
				else
				{
					offices = await FindOfficesAsync(latitude, longitude, radius, serviceType, serviceIds, token);
					atms = await FindAtmsAsync(latitude, longitude, radius, serviceType, serviceIds, token);
				}


				return new PointsInRadiusModel()
				{
					Offices = offices,
					Atms = atms
				};

			}
			catch (Exception ex)
			{
				string message = "Ошибка во время получения точек";
				_logger.LogError(ex, message);
				throw new Exception(message);
			}
		}

		private async Task<OfficeModel[]> FindOfficesAsync(double latitude, double longitude, double radius,
			ServiceType? serviceType,  List<long> serviceIds, CancellationToken token)
		{
			using (var context = await _dbContextFactory.CreateDbContextAsync())
			{
				var coordinate = new Coordinate(latitude, longitude);
				Point point = new Point(coordinate) { SRID = 4326 };

				var dbOffices = await context.Offices
					.AsNoTracking()
					.Include(x => x.OfficeServices)
					.ThenInclude(x => x.Service)
					.Include(x => x.IndividualSchedule)
					.Include(x => x.LegalEntitySchedule)
					.Where(x => x.Location.Distance(point) <= radius)
					.Where(x => x.OfficeServices.Any(y => (serviceType == null || y.Service.Type == serviceType) &&
					(serviceIds.IsNullOrEmpty() || serviceIds.Contains(y.serviceId))))
					.ToArrayAsync(token);

				  OfficeModel[] offices = dbOffices
					.Select(x => new OfficeModel(x))
					.ToArray();

				if (!offices.Any())
				{
					var nearest = await context.Offices
						.Include(x => x.IndividualSchedule)
						.Include(x => x.LegalEntitySchedule)
						.OrderBy(x => x.Location.Distance(point))
						.FirstOrDefaultAsync(token);

					if (nearest != null)
					{
						offices = new OfficeModel[] {
								new OfficeModel(nearest)
							};
					}
				}


				return offices;
			}
		}

		private async Task<AtmModel[]> FindAtmsAsync(double latitude, double longitude, double radius, ServiceType? serviceType, List<long> serviceIds, CancellationToken token)
		{
			var coordinate = new Coordinate(latitude, longitude);
			var point = new NetTopologySuite.Geometries.Point(coordinate) { SRID = 4326 };

			try
			{
				using (var context = await _dbContextFactory.CreateDbContextAsync())
				{
					var dbAtms = await context.Atms
						.Include(x => x.AtmServices)
						.ThenInclude(x => x.Service)
					.Where(x => x.Location.Distance(point) <= radius)
					.Where(x => x.AtmServices.Any(y => (serviceType == null || y.Service.Type == serviceType) &&
						(serviceIds.IsNullOrEmpty() || serviceIds.Contains(y.serviceId))))
					.ToArrayAsync(token);

					AtmModel[] atms = dbAtms
						.Select(x => new AtmModel(x))
						.ToArray();

					if (!atms.Any())
					{
						var nearest = await context.Atms
						.AsNoTracking()
							.OrderBy(x => x.Location.Distance(point))
							.FirstOrDefaultAsync(token);

						if (nearest != null)
						{
							atms = new AtmModel[] {
								new AtmModel(nearest)
							};
						}
					}

					return atms;
				}
			}
			catch (Exception ex)
			{
				string message = "Ошибка во время получения точек";
				_logger.LogError(ex, message);
				throw new Exception(message);
			}

		}

		public async Task TakeTicket(TakeTicketRequest request, CancellationToken token)
		{
			try
			{
				UpdateOfficeWorkloadRequest newRequest;
				switch (request.TakeTicketType)
				{
					case TakeTicketType.TakeAt:
						if (request.Time < DateTime.Now)
							throw new Exception("Неверное время взятия билета");

						var deltaTime = request.Time - DateTime.Now;
						await Task.Delay(deltaTime, token);
						break;

					case TakeTicketType.LeaveAt:
						if (request.Time < DateTime.Now)
							throw new Exception("Неверное время отправки");

						var wayTime = TimeSpan.FromMinutes(request.WayTime.Ticks);
						var arriveTime = DateTime.Now.Add(wayTime);

						await DelayTicketSending(request, token, arriveTime);
						break;

					case TakeTicketType.ComeAt:
						await DelayTicketSending(request, token, request.Time);
						break;
				}
				newRequest = new UpdateOfficeWorkloadRequest() { OfficeId = request.OfficeId, ServiceId = request.ServiceId, IsCompleted = false };
				await UpdateOfficeWorkloadAsync(newRequest, token);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				throw new Exception(ex.Message);
			}
		}

		private async Task DelayTicketSending(TakeTicketRequest request, CancellationToken token, DateTime arriveTime)
		{
			var waitingTime = await GetOfficeServiceWorkload(request.OfficeId, request.ServiceId, token);
			var queueTime = DateTime.Now.AddMinutes(waitingTime);

			var maxAttempts = 10;
			var attempt = 0;

			while (queueTime > arriveTime && attempt < maxAttempts)
			{
				var deltaTime = arriveTime - queueTime;
				if (deltaTime > TimeSpan.Zero)
				{
					await Task.Delay(deltaTime, token);
				}

				waitingTime = await GetOfficeServiceWorkload(request.OfficeId, request.ServiceId, token);
				queueTime = DateTime.Now.AddMinutes(waitingTime);

				attempt++;
			}
		}

		public async Task UpdateOfficeWorkloadAsync(UpdateOfficeWorkloadRequest request, CancellationToken token)
		{
			try
			{
				// получаем все окна отделения для нашей операции
				using (var context = await _dbContextFactory.CreateDbContextAsync())
				{
					var office = await context.Offices
						.Where(x => x.Id == request.OfficeId)
						.Include(x => x.Windows)
							.ThenInclude(w => w.WindowServices)
								.ThenInclude(ws => ws.Service)
						.FirstOrDefaultAsync();

					if (office == null)
						return;

					var avaliableWindows = office.Windows.Where(x => x.WindowServices.Any(ws => ws.Service.Id == request.ServiceId));

					var service = avaliableWindows.FirstOrDefault()?.WindowServices.FirstOrDefault(ws => ws.Service.Id == request.ServiceId)?.Service;

					if (service == null)
						return;

					// изменяем время ожидания в окнах
					foreach (var window in avaliableWindows)
					{
						if (request.IsCompleted)
						{
							window.BusyTime -= service.AverageWaitTime / avaliableWindows.Count();
							office.WorkLoad -= service.AverageWaitTime / office.Windows.Count();
						}

						else
						{
							window.BusyTime += service.AverageWaitTime / avaliableWindows.Count();
							office.WorkLoad += service.AverageWaitTime / office.Windows.Count();
						}
					}

					await context.SaveChangesAsync();
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				throw new Exception(ex.Message);
			}

		}
		public async Task<PointShotModel[]> SearchPointsAsync(string search, RoutePoint? userCoordinates, CancellationToken token)
		{
			search = search?.ToLower();
			try
			{
				var points = await Task.WhenAll(SearchAtms(search, userCoordinates, token), SearchOffices(search, userCoordinates, token));

				if (points == null || points.Length != 2)
					throw new Exception("Ошибка во время поиска точек");

				var atms = points[0];
				var offices = points[1];

				var result = atms.Union(offices);

				return result
					.OrderByDescending(x => x.DistanceMetres ?? double.MaxValue)
					.ThenBy(x => x.Name)
					.ToArray();
			}
			catch (Exception ex)
			{
				string message = "Ошибка поиска точек";
				_logger.LogError(ex, message);

				throw new Exception(message);
			}
		}

		private async Task<PointShotModel[]> SearchOffices(string search, RoutePoint? userCoordinates, CancellationToken token)
		{
			if (string.IsNullOrEmpty(search))
			{
				return Array.Empty<PointShotModel>();
			}

			string[] words = search.Split(' ');

			if (words.Length > 2)
			{
				words = new string[] { words[0], words[1] };
			}

			IQueryable<Office> offices;

			using (var context = await _dbContextFactory.CreateDbContextAsync())
			{
				if (words.Length == 1)
				{
					string word = words[0];

					offices = context.Offices
						.Where(x => x.Name.ToLower().Contains(word) ||
							(x.Address != null && x.Address.ToLower().Contains(word)) ||
							(x.MetroStation != null && x.MetroStation.ToLower().Contains(word)));
				}
				else
				{
					offices = context.Offices
						.Where(x => x.Name.ToLower().Contains(words[0]) || x.Name.ToLower().Contains(words[1]) ||
							x.Address != null && (x.Address.ToLower().Contains(words[0]) || x.Address.ToLower().Contains(words[1])) ||
							(x.MetroStation != null && (x.MetroStation.ToLower().Contains(words[0]) || x.MetroStation.ToLower().Contains(words[1]))));
				}

				Point? point = null;

				if (userCoordinates != null)
				{
					var coordinate = new Coordinate(userCoordinates.Latitude, userCoordinates.Longitude);
					point = new Point(coordinate) { SRID = 4326 };
				}

				return await offices
					.Select(x => new PointShotModel
					{
						Id = x.Id,
						Address = x.Address,
						Type = PointType.Office,
						Name = x.Name,
						DistanceMetres = point != null
							? x.Location.Distance(point)
							: null
					})
					.Take(10)
					.ToArrayAsync(token);
			}


		}

		private async Task<PointShotModel[]> SearchAtms(string search, RoutePoint? userCoordinates, CancellationToken token)
		{
			if (string.IsNullOrEmpty(search))
			{
				return Array.Empty<PointShotModel>();
			}

			string[] words = search.Split(' ');

			if (words.Length > 2)
			{
				words = new string[] { words[0], words[1] };
			}

			IQueryable<Atm> atms;

			using (var context = await _dbContextFactory.CreateDbContextAsync())
			{
				if (words.Length == 1)
				{
					string word = words[0];

					atms = context.Atms
						.Where(x => x.Address != null && x.Address.ToLower().Contains(word));
				}
				else
				{
					atms = context.Atms
						.Where(x => x.Address != null && (x.Address.ToLower().Contains(words[0]) || x.Address.ToLower().Contains(words[1])));
				}

				Point? point = null;

				if (userCoordinates != null)
				{
					var coordinate = new Coordinate(userCoordinates.Latitude, userCoordinates.Longitude);
					point = new Point(coordinate) { SRID = 4326 };
				}

				return await atms
					.Select(x => new PointShotModel
					{
						Id = x.Id,
						Address = x.Address,
						Type = PointType.Atm,
						Name = "Банкомат",
						DistanceMetres = point != null
							? x.Location.Distance(point)
							: null
					})
					.Take(10)
					.ToArrayAsync(token);
			}


		}
	}
}