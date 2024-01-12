using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace StoreApp.Infrastructe.Mapper
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
			CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
		}
    }
}
