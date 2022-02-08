using Microsoft.Extensions.DependencyInjection;

using SampleMunicornNotion.BL.Services;
using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.BL;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddNotionSenders(this IServiceCollection services)
	{
		services.AddTransient<INotionSender<AndroidNotion>, AndroidNotionSender>();
		services.AddTransient<INotionSender<IOSNotion>, IOSNotionSender>();
		return services;
	}
}
