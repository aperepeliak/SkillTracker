using AutoMapper;
using ST.BLL.DTOs;
using ST.WebUI.ViewModels;

namespace ST.WebUI
{
    public class MappingVMProfile : Profile
    {
        public MappingVMProfile()
        {
            Mapper.CreateMap<DeveloperDto, DeveloperViewModel>();
        }
    }
}
