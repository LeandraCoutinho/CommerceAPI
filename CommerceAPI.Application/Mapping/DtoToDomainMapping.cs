using AutoMapper;
using CommerceAPI.Application.DTOs;
using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Application.Mapping;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<PersonDTO, Person>();
        CreateMap<ProductDTO, Product>();
    }
}