using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightFireMoreTech5.Data.EntitiesConfiguration;
internal class WindowServiceConfiguration : IEntityTypeConfiguration<WindowService>
{
	public void Configure(EntityTypeBuilder<WindowService> builder)
	{
		builder
			.ToTable("window_service");

		builder
			.HasKey(x => new { x.windowId, x.serviceId });

		builder
			.HasOne(x => x.Window)
			.WithMany()
			.HasForeignKey(x => x.windowId);

		builder
			.HasOne(x => x.Service)
			.WithMany()
			.HasForeignKey(x => x.serviceId);
	}
}
