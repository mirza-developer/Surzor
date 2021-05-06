using AutoMapper;
using Surzor.App.Services.Base;
using Surzor.App.ViewModels;

namespace Surzor.App.Profiles
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<AllResponderListVm, ResponderListViewModel>().ReverseMap();
        }
    }
}
