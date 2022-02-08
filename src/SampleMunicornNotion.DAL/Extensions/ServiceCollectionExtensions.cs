using Microsoft.Extensions.DependencyInjection;

using SampleMunicornNotion.DAL.Repositories;

namespace SampleMunicornNotion.DAL;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
	{
		services.AddTransient<AndroidNotionRepository>();
		services.AddTransient<IOSNotionRepository>();
		return services;
	}
}
