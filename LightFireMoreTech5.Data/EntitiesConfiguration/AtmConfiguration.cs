using LightFireMoreTech5.Data.Entities;
using LightFireMoreTech5.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightFireMoreTech5.Data.EntitiesConfiguration
{
	internal class AtmConfiguration : IEntityTypeConfiguration<Atm>
	{
		public void Configure(EntityTypeBuilder<Atm> builder)
		{
			builder
				.ToTable("atms");

			builder
			   .HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				 .ValueGeneratedOnAdd();

			builder.Property(e => e.Location)
			   .HasColumnType("geography (Point,4326)")
			   .IsRequired();

			builder.HasIndex(e => e.Location)
			   .HasMethod("GIST");

			builder.Property(x => x.WheelChairCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.WheelChairActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.BlindCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.BlindChairActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.NfcBankCardsCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.NfcBankCardsActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.QrReadCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.QrReadActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportUsdCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportUsdActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportChargeRubCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportChargeRubActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportEurCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportEurActivity)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportRubCapability)
				.HasColumnType("int")
				.IsRequired(true);

			builder.Property(x => x.SupportRubCapability)
				.HasColumnType("int")
				.IsRequired(true);
		}
	}
}
