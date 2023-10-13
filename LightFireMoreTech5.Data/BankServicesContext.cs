using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LightFireMoreTech5.Data
{
	public class BankServicesContext : DbContext
	{
		public DbSet<Atm> Atms { get; set; }
		public DbSet<Office> Offices { get; set; }

		public BankServicesContext(DbContextOptions<BankServicesContext> options)
		: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.HasPostgresExtension("postgis");

			builder.ApplyConfiguration(new AtmConfiguration());
			builder.ApplyConfiguration(new OfficeConfiguration());
		}

	}
}
