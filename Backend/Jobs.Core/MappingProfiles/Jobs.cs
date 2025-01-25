using AutoMapper;
using Jobs.Core.DTOs;
using Jobs.Core.Models;

namespace Jobs.Core.MappingProfiles;
public class JobsProfile : Profile
{
    public JobsProfile()
    {
        CreateMap<PositionDTO, Position>().ReverseMap();
        CreateMap<PositionApplicationsDTO, PositionApplication>().ReverseMap();
    }
}
