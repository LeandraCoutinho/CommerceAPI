using AutoMapper;
using MP.ApiDotNet7.Domain.Entities;
using MP.ApiDotNet7.Application.DTOs;

namespace MP.ApiDotNet7.Application.Mapping;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<PersonDTO, Person>();
        CreateMap<ProductDTO, Product>();
    }
}