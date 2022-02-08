using Microsoft.Extensions.Logging;

using SampleMunicornNotion.DAL.Repositories;
using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.BL.Services
{
	public class AndroidNotionSender : INotionSender<AndroidNotion>
	{
		private readonly AndroidNotionRepository repository;
		private readonly ILogger<AndroidNotionSender> logger;

		private static readonly Random random = new();
		private static int counter = 0;

		public string Name => "Sender для Android";

		public AndroidNotionSender(AndroidNotionRepository repository, ILogger<AndroidNotionSender> logger)
		{
			this.repository = repository;
			this.logger = logger;
		}

		/// <inheritdoc/>
		public async Task<AndroidNotion> SendNotion(AndroidNotion notion)
		{
			if (notion == null)
				throw new InvalidOperationException($"nameof(notion) is null");

			logger.LogInformation($"Sending new Android notion: {notion}");

			var delay = TimeSpan.FromMilliseconds(random.Next(500, 2000));
			await Task.Delay(delay);

			var current = Interlocked.Increment(ref counter);
			var status = current % 5 == 0
				? ProcessingStatus.Failed
				: ProcessingStatus.Sent;

			logger.LogInformation($"Send Android notion {notion.Id}: status {status}");

			return await repository.SaveStatus(notion, status);
		}
	}
}
