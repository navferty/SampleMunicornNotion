using AutoMapper;

using SampleMunicornNotion.DAL.Entities;
using SampleMunicornNotion.Models;
using SampleMunicornNotion.Models.Android;
using SampleMunicornNotion.Models.IOS;

namespace SampleMunicornNotion.DAL.Mapping;

public class EntityMappingProfile : Profile
{
	public EntityMappingProfile()
	{
		CreateMap<AndroidNotionEntity, AndroidNotion>();
		CreateMap<IOSNotionEntity, IOSNotion>();

		CreateMap<NewAndroidNotionDto, AndroidNotionEntity>();
		CreateMap<NewIOSNotionDto, IOSNotionEntity>();
	}
}
