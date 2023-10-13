using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightFireMoreTech5.Data.EntitiesConfiguration
{
	internal class OfficeConfiguration : IEntityTypeConfiguration<Office>
	{
		public void Configure(EntityTypeBuilder<Office> builder)
		{
			builder
				.ToTable("offices");

			builder
			   .HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				 .ValueGeneratedOnAdd();

			builder.Property(e => e.Location)
			   .HasColumnType("geography (Point,4326)")
			   .IsRequired();

			builder.Property(e => e.Name)
				.HasColumnType("text")
				.IsRequired(false);

			builder.Property(e => e.Address)
				.HasColumnType("text")
				.IsRequired(false);

			builder.Property(e => e.MetroStation)
				.HasColumnType("text")
				.IsRequired(false);

			builder.Property(e => e.AllDay)
				.HasColumnType("bool")
				.IsRequired(false);

			builder.Property(e => e.Rko)
				.HasColumnType("bool")
				.IsRequired(false);

			builder.Property(e => e.HasRamp)
				.HasColumnType("bool")
				.IsRequired(false);

			builder.Property(e => e.MyOffice)
				.HasColumnType("bool")
				.IsRequired(false);

			builder.Property(e => e.OfficeType)
				.HasColumnType("text")
				.IsRequired(false);

			builder.Property(e => e.SalePointFormat)
				.HasColumnType("text")
				.IsRequired(false);

			builder.Property(e => e.LegalEntityShceduleId)
				.HasColumnType("bigint")
				.IsRequired(true);

			builder.Property(e => e.IndividualShceduleId)
				.HasColumnType("bigint")
				.IsRequired(true);

			builder.Property(e => e.Kep)
				.HasColumnType("bigint")
				.IsRequired(false);

			builder.HasIndex(e => e.Location)
			   .HasMethod("GIST");

			builder.HasOne(e => e.LegalEntitySchedule)
				.WithMany(e => e.LegalEntitiesOffices)
				.HasForeignKey(e => e.LegalEntityShceduleId);

			builder.HasOne(e => e.IndividualSchedule)
				.WithMany(e => e.IndividualOffices)
				.HasForeignKey(e => e.IndividualShceduleId);
		}
	}
}
