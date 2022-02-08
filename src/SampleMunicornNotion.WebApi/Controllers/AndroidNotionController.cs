using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SampleMunicornNotion.BL.Services;
using SampleMunicornNotion.DAL.Repositories;
using SampleMunicornNotion.Models;
using SampleMunicornNotion.Models.Android;
using SampleMunicornNotion.WebApi.Models;

namespace SampleMunicornNotion.WebApi.Controllers
{
	[ApiController]
	[Route("android")]
	public class AndroidNotionController : ControllerBase
	{
		private readonly AndroidNotionRepository repository;
		private readonly INotionSender<AndroidNotion> notionSender;
		private readonly IMapper mapper;

		public AndroidNotionController(
			AndroidNotionRepository repository,
			INotionSender<AndroidNotion> notionSender,
			IMapper mapper)
		{
			this.repository = repository;
			this.notionSender = notionSender;
			this.mapper = mapper;
		}

		/// <summary>
		/// Получить android notion по идентификатору
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<AndroidNotionDto>> GetAndroidNotificationById(long id)
		{
			var androidNotion = await repository.FindById(id);

			return androidNotion != null
				? mapper.Map<AndroidNotionDto>(androidNotion)
				: NotFound($"Notion not found by id {id}");
		}

		/// <summary>
		/// Отправить новую нотификацию
		/// </summary>
		/// <param name="notion"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<AndroidNotionDto>> PostAndroidNotion(NewAndroidNotionDto notion)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var androidNotion = await repository.Create(notion);

			var sentNotion = await notionSender.SendNotion(androidNotion);

			return mapper.Map<AndroidNotionDto>(sentNotion);
		}
	}
}
