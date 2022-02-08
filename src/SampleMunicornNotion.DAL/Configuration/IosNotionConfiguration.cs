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
	public class IosNotionConfiguration : IEntityTypeConfiguration<IOSNotionEntity>
	{
		public void Configure(EntityTypeBuilder<IOSNotionEntity> builder)
		{
			builder
				.Property(x => x.PushToken)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(x => x.Alert)
				.IsRequired()
				.HasMaxLength(2000);

			builder
				.Property(x => x.Priority)
				.IsRequired()
				.HasDefaultValue(10);
			builder
				.Property(x => x.IsBackground)
				.IsRequired()
				.HasDefaultValue(true); // TODO уточнить дефолтное

			builder
				.Property(x => x.CreatedAt)
				.HasDefaultValueSql("now() at time zone 'utc'");
		}
	}
}
