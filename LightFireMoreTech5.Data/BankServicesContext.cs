using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.EntitiesConfiguration;
using LightFireMoreTech5.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace LightFireMoreTech5.Data
{
	public class BankServicesContext : DbContext
	{
		public DbSet<Atm> Atms { get; set; }
		public DbSet<Office> Offices { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<AtmService> AtmServices { get; set; }
		public DbSet<OfficeService> OfficeServices { get; set; }
		public DbSet<OfficeSchedule> OfficeSchedules { get; set; }

		public BankServicesContext(DbContextOptions<BankServicesContext> options)
		: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasPostgresExtension("postgis");

			builder.ApplyConfiguration(new AtmConfiguration());
			builder.ApplyConfiguration(new OfficeConfiguration());
			builder.ApplyConfiguration(new ServiceConfiguration());
			builder.ApplyConfiguration(new OfficeScheduleConfiguration());
			builder.ApplyConfiguration(new OfficeServiceServiceConfiguration());
			builder.ApplyConfiguration(new AtmServiceServiceConfiguration());
		}

	}
}
