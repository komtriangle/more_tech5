using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LightFireMoreTech5.Data.EntitiesConfiguration
{
	internal class OfficeScheduleConfiguration : IEntityTypeConfiguration<OfficeSchedule>
	{
		public void Configure(EntityTypeBuilder<OfficeSchedule> builder)
		{
			builder
			.ToTable("office_schedule");

			builder
			   .HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				 .ValueGeneratedOnAdd();

			builder
				.Property(x => x.MondayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.MondayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.TuesdayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.TuesdayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.ThursdayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.ThursdayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);


			builder
				.Property(x => x.WednesdayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.WednesdayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.FridayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.FridayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.SaturdayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.SaturdayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.SundayStart)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);

			builder
				.Property(x => x.SundayEnd)
				.HasColumnType("text")
				.HasConversion(
					x => x.ToString(),
					x => TimeOnly.Parse(x))
				.IsRequired(false);
		}
	}
}
