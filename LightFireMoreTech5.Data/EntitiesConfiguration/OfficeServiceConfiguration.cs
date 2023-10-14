using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightFireMoreTech5.Data.EntitiesConfiguration;
internal class OfficeServiceServiceConfiguration : IEntityTypeConfiguration<OfficeService>
{
	public void Configure(EntityTypeBuilder<OfficeService> builder)
	{
		builder
			.ToTable("office_service");

		builder
			.HasKey(x => new { x.officeId, x.serviceId });

		builder
			.HasOne(x => x.Office)
			.WithMany(x => x.OfficeServices)
			.HasForeignKey(x => x.officeId);

		builder
			.HasOne(x => x.Service)
			.WithMany(x => x.OfficeServices)
			.HasForeignKey(x => x.serviceId);
	}
}
