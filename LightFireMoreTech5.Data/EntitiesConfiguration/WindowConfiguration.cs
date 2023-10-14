using LightFireMoreTech5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightFireMoreTech5.Data.EntitiesConfiguration;
internal class WindowConfiguration : IEntityTypeConfiguration<Window>
{
	public void Configure(EntityTypeBuilder<Window> builder)
	{
		builder
			.ToTable("window");

		builder
		   .HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			 .ValueGeneratedOnAdd();

		builder
			.HasOne(x => x.Office)
			.WithMany()
			.HasForeignKey(x => x.officeId);	
	}
}
