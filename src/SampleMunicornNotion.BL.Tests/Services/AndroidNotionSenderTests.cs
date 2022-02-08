using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Moq;

using SampleMunicornNotion.BL.Services;
using SampleMunicornNotion.DAL.Repositories;
using SampleMunicornNotion.Models;

using Xunit;
using Xunit.Abstractions;

namespace SampleMunicornNotion.BL.Tests.Services
{
	public class AndroidNotionSenderTests
	{
		private readonly AndroidNotionSender notionSender;
		private readonly Mock<AndroidNotionRepository> repoMock;

		public AndroidNotionSenderTests(ITestOutputHelper outputHelper)
		{
			repoMock = new Mock<AndroidNotionRepository>(null, null);

			var logger = new LoggerFactory().CreateLogger<AndroidNotionSender>();

			notionSender = new(repoMock.Object, logger);
		}

		[Fact]
		public async Task SendNotion_NotionIsProcessed()
		{
			var notion = new AndroidNotion
			{
				Id = 1,
				Title = "message",
				Condition = "test",
				DeviceToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9" +
				".eyJuYW1lIjoi0L_QsNGB0YXQsNC70L7Rh9C60LAiLCJjb250ZW50IjpbIi0g0JXRgdGC0Ywg0L3QsCDQsdC-0YDRgtGDINCz0L7QvNC10L7Qv9Cw0YI_IiwiLSDQkCDRh9GC0L4g0YHQu9GD0YfQuNC70L7RgdGMPyIsIi0g0JDRgdGC0YDQvtC70L7Qs9GDINC_0LvQvtGF0L4hIl19",
				Message = "see token",
				CreatedAt = DateTime.UtcNow,
				Status = ProcessingStatus.Created,
			};
			repoMock
				.Setup(x => x.SaveStatus(notion, It.IsAny<ProcessingStatus>()))
				.ReturnsAsync(notion);

			var result = await notionSender.SendNotion(notion);

			Assert.NotNull(result);
			repoMock.Verify(
				x => x.SaveStatus(notion, It.Is<ProcessingStatus>(s => s != ProcessingStatus.Created)),
				Times.Once);
		}

		[Fact]
		public async Task SendManyNotions_SomeNotionsAreFailed()
		{
			var notion = new AndroidNotion
			{
				Id = 2,
				Title = "message",
				Condition = "test",
				DeviceToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoi0L_QsNGB0YXQsNC70L7Rh9C60LAiLCJjb250ZW50IjoiLSDQkdC70LjQvSEgLSDRgdC60LDQt9Cw0Lsg0YHQu9C-0L0sINC90LDRgdGC0YPQv9C40LIg0L3QsCDQutC-0LvQvtCx0LrQsCJ9",
				Message = "see token again",
				CreatedAt = DateTime.UtcNow,
				Status = ProcessingStatus.Created,
			};
			repoMock
				.Setup(x => x.SaveStatus(notion, It.IsAny<ProcessingStatus>()))
				.ReturnsAsync(notion);

			for (int i = 0; i < 20; i++)
				_ = await notionSender.SendNotion(notion);

			repoMock.Verify(
				x => x.SaveStatus(notion, It.Is<ProcessingStatus>(s => s == ProcessingStatus.Failed)),
				Times.Exactly(4));
			repoMock.Verify(
				x => x.SaveStatus(notion, It.Is<ProcessingStatus>(s => s == ProcessingStatus.Sent)),
				Times.Exactly(16));
		}
	}
}
