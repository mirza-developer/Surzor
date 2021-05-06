using AutoMapper;
using Surzor.Application.Profiles.CustomConverters;
using Surzor.Domain.Entities;
using System;
using Surzor.Application.Features.Responders.Commands;
using Surzor.Application.Features.Responders.Queries;

namespace Surzor.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, Guid?>().ConvertUsing<EmptyStringToGuid>();
            CreateMap<Responder, AllResponderListVm>().ReverseMap();
            CreateMap<Responder, CreateResponderCommand>().ReverseMap();
            CreateMap<Responder, ResponderExportDto>().ReverseMap();
        }
    }

}
