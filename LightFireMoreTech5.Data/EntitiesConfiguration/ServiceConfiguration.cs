using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightFireMoreTech5.Data.EntitiesConfiguration;
internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
	public void Configure(EntityTypeBuilder<Service> builder)
	{
		builder
			.ToTable("service");

		builder
		   .HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			 .ValueGeneratedOnAdd();
	}
}
