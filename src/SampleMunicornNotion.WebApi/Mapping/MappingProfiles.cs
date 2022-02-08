using AutoMapper;

using SampleMunicornNotion.Models;
using SampleMunicornNotion.WebApi.Models;

namespace SampleMunicornNotion.WebApi.Mapping;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<AndroidNotion, AndroidNotionDto>();
		CreateMap<IOSNotion, IOSNotionDto>();
	}
}
