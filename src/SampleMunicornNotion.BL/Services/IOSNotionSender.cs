using Microsoft.Extensions.Logging;

using SampleMunicornNotion.DAL.Repositories;
using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.BL.Services
{
	public class IOSNotionSender : INotionSender<IOSNotion>
	{
		private readonly IOSNotionRepository repository;
		private readonly ILogger<IOSNotionSender> logger;

		private static readonly Random random = new();
		private static int counter = 0;

		public string Name => "Sender для iOS";

		public IOSNotionSender(IOSNotionRepository repository, ILogger<IOSNotionSender> logger)
		{
			this.repository = repository;
			this.logger = logger;
		}

		/// <inheritdoc/>
		public async Task<IOSNotion> SendNotion(IOSNotion notion)
		{
			logger.LogInformation($"Sending new iOS notion: {notion}");

			var delay = TimeSpan.FromMilliseconds(random.Next(500, 2000));
			await Task.Delay(delay);

			var current = Interlocked.Increment(ref counter);
			var status = current % 5 == 0
				? ProcessingStatus.Failed
				: ProcessingStatus.Sent;

			logger.LogInformation($"Send iOS notion {notion.Id}: status {status}");

			return await repository.SaveStatus(notion, status);
		}
	}
}
