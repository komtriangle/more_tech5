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
		}
	}
}
