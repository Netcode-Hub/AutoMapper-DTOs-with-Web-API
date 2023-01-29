using AutoMapper;
using EFCoreRelationships.DTOs;
using EFCoreRelationships.Models;

namespace EFCoreRelationships.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
                   //  From Db -  Client 
            CreateMap<Employee, ResponseDTO>();

                   // From Client - Db
            CreateMap<RequestDTO, Employee>();
        }
    }
}
