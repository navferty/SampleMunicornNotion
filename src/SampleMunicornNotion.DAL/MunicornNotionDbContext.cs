using Microsoft.EntityFrameworkCore;

using SampleMunicornNotion.DAL.Entities;

namespace SampleMunicornNotion.DAL
{
	public class MunicornNotionDbContext : DbContext
	{
		public MunicornNotionDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<AndroidNotionEntity> AndroidNotifications { get; set; } = null!;
		public DbSet<IOSNotionEntity> IosNotifications { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MunicornNotionDbContext).Assembly);
		}
	}
}
