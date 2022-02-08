using AutoMapper;

using SampleMunicornNotion.DAL.Entities;
using SampleMunicornNotion.Models;
using SampleMunicornNotion.Models.IOS;

namespace SampleMunicornNotion.DAL.Repositories
{
	public class IOSNotionRepository
	{
		private readonly MunicornNotionDbContext dbContext;
		private readonly IMapper mapper;

		public IOSNotionRepository(MunicornNotionDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<IOSNotion> Create(NewIOSNotionDto notion)
		{
			var newNotion = mapper.Map<IOSNotionEntity>(notion);
			dbContext.IosNotifications.Add(newNotion);
			await dbContext.SaveChangesAsync();
			return mapper.Map<IOSNotion>(newNotion);
		}

		public async Task<IOSNotion?> FindById(long id)
		{
			var notion = await dbContext.IosNotifications.FindAsync(id);
			if (notion == null)
				return null;
			return mapper.Map<IOSNotion>(notion);
		}

		public async Task<IOSNotion> SaveStatus(IOSNotion notion, ProcessingStatus status)
		{
			var entity = await dbContext.IosNotifications.FindAsync(notion.Id);
			if (entity == null)
				throw new InvalidOperationException($"failed to find iOS notion by id {notion.Id}!");

			entity.Status = status;
			await dbContext.SaveChangesAsync();

			return mapper.Map<IOSNotion>(entity);
		}
	}
}
