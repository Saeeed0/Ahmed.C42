using Ahmed.C42.BLL.CustomModel.Departments;
using Ahmed.C42.PL.ViewModels.Departments;
using AutoMapper;

namespace Ahmed.C42.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Department
            CreateMap<DepartmentDetailsDto,DepartmentViewModel>()
                /*.ForMember(dest => dest.NameX , config => config.MapFrom(src => src.Name));*/

                //.ReverseMap()
                /*.ForMember(dest => dest.Name , config => config.MapFrom(src => src.NameX))*/
                ;

            CreateMap<DepartmentViewModel, UpdatedDepartmentDto>();

            #endregion

            #region Employee

            #endregion
        }
    }
}
