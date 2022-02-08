using AutoMapper;

using SampleMunicornNotion.DAL.Entities;
using SampleMunicornNotion.Models;
using SampleMunicornNotion.Models.Android;

namespace SampleMunicornNotion.DAL.Repositories
{
	public class AndroidNotionRepository
	{
		private readonly MunicornNotionDbContext dbContext;
		private readonly IMapper mapper;

		public AndroidNotionRepository(MunicornNotionDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<AndroidNotion?> FindById(long id)
		{
			var androidNotionEntity = await dbContext.AndroidNotifications.FindAsync(id);
			return androidNotionEntity != null
				? mapper.Map<AndroidNotion>(androidNotionEntity)
				: null;
		}

		public async Task<AndroidNotion> Create(NewAndroidNotionDto notion)
		{
			var newNotion = mapper.Map<AndroidNotionEntity>(notion);
			dbContext.AndroidNotifications.Add(newNotion);
			await dbContext.SaveChangesAsync();
			return mapper.Map<AndroidNotion>(newNotion);
		}

		public virtual async Task<AndroidNotion> SaveStatus(AndroidNotion notion, ProcessingStatus status)
		{
			var entity = await dbContext.AndroidNotifications.FindAsync(notion.Id);
			if (entity == null)
				throw new InvalidOperationException($"failed to find android notion by id {notion.Id}!");

			entity.Status = status;
			await dbContext.SaveChangesAsync();

			return mapper.Map<AndroidNotion>(entity);
		}
	}
}
