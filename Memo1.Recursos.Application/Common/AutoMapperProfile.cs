using AutoMapper;
using Memo1.Recursos.Application.Dtos.CargaHorarias;
using Memo1.Recursos.Domain;

namespace Memo1.Recursos.Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateCargaHorariaDto, CargaHoraria>();
        CreateMap<CargaHorariaDto, CargaHoraria>().ReverseMap();
        CreateMap<UpdateCargaHorariaDto, CargaHoraria>();
    }
}
    
