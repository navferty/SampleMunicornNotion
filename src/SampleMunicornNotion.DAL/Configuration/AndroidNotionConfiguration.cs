using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SampleMunicornNotion.DAL.Entities;

namespace SampleMunicornNotion.DAL.Configuration
{
	public class AndroidNotionConfiguration : IEntityTypeConfiguration<AndroidNotionEntity>
	{
		public void Configure(EntityTypeBuilder<AndroidNotionEntity> builder)
		{
			builder
				.Property(x => x.DeviceToken)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(x => x.Message)
				.IsRequired()
				.HasMaxLength(2000);
			builder
				.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(255);
			builder
				.Property(x => x.Condition)
				.IsRequired(false)
				.HasMaxLength(2000);

			builder
				.Property(x => x.CreatedAt)
				.HasDefaultValueSql("now() at time zone 'utc'");
		}
	}
}
