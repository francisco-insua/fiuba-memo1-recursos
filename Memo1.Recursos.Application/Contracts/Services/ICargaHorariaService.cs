using Memo1.Recursos.Application.Dtos.CargaHorarias;
using Memo1.Recursos.Application.Responses;

namespace Memo1.Recursos.Application.Contracts.Services;

public interface ICargaHorariaService
{
    Task<BaseResponse> CreateCargaHoraria(CreateCargaHorariaDto createUserDto);
    Task<BaseResponse> DeleteCargaHoraria(string id);
    Task<CargaHorariaDto?> GetCargaHoraria(string id);
}