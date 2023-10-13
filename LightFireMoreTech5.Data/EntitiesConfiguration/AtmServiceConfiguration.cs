using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightFireMoreTech5.Data.EntitiesConfiguration;
internal class AtmServiceServiceConfiguration : IEntityTypeConfiguration<AtmService>
{
	public void Configure(EntityTypeBuilder<AtmService> builder)
	{
		builder
			.ToTable("atm_service");

		builder
		    .HasKey(x => new { x.atmId, x.serviceId });

		builder
			.HasOne(x => x.Atm)
			.WithMany()
			.HasForeignKey(x => x.atmId);

		builder
			.HasOne(x => x.Service)
			.WithMany()
			.HasForeignKey(x => x.serviceId);
	}
}
