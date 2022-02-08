using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SampleMunicornNotion.BL.Services;
using SampleMunicornNotion.DAL.Repositories;
using SampleMunicornNotion.Models;
using SampleMunicornNotion.Models.IOS;
using SampleMunicornNotion.WebApi.Models;

namespace SampleMunicornNotion.WebApi.Controllers
{
	[ApiController]
	[Route("ios")]
	public class IOSNotionController : ControllerBase
	{
		private readonly IOSNotionRepository repository;
		private readonly INotionSender<IOSNotion> notionSender;
		private readonly IMapper mapper;

		public IOSNotionController(
			IOSNotionRepository repository,
			INotionSender<IOSNotion> notionSender,
			IMapper mapper)
		{
			this.repository = repository;
			this.notionSender = notionSender;
			this.mapper = mapper;
		}

		/// <summary>
		/// Получить IOS notion по идентификатору
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<IOSNotionDto>> GetIOSNotificationById(long id)
		{
			var notion = await repository.FindById(id);

			return notion != null
				? mapper.Map<IOSNotionDto>(notion)
				: NotFound($"Notion not found by id {id}");
		}

		/// <summary>
		/// Отправить новую нотификацию
		/// </summary>
		/// <param name="newNotion"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<IOSNotionDto>> PostIOSNotion(NewIOSNotionDto newNotion)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var notion = await repository.Create(newNotion);

			var sentNotion = await notionSender.SendNotion(notion);

			return mapper.Map<IOSNotionDto>(sentNotion);
		}
	}
}
