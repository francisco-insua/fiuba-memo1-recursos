using AutoMapper;
using Memo1.Recursos.Application.Contracts.Repositories;
using Memo1.Recursos.Application.Contracts.Services;
using Memo1.Recursos.Application.Dtos.CargaHorarias;
using Memo1.Recursos.Application.Responses;
using Memo1.Recursos.Domain;

namespace Memo1.Recursos.Infrastructure.Services;

public class CargaHorariaService: ICargaHorariaService
{
    private readonly ICargaHorariaRepository _cargaHorariaRepository;
    private readonly IMapper _mapper;
    
    public CargaHorariaService(
        ICargaHorariaRepository cargaHorariaRepository, 
        IMapper mapper)
    {
        _cargaHorariaRepository = cargaHorariaRepository;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse> CreateCargaHoraria(CreateCargaHorariaDto createCargaHorariaDto)
    {
        try
        {
            var cargaHoraria = _mapper.Map<CargaHoraria>(createCargaHorariaDto);
            cargaHoraria.Id = Guid.NewGuid().ToString();
            
            await _cargaHorariaRepository.Add(cargaHoraria);
            
            return new BaseResponse(true, cargaHoraria.Id);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, "", e.Message);
        }
    }

    public async Task<BaseResponse> DeleteCargaHoraria(string id)
    {
        try
        {
            
            await _cargaHorariaRepository.Delete(id);

            return new BaseResponse(true, id);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, "", e.Message);
        }
    }

    public async Task<CargaHorariaDto> GetCargaHoraria(string id)
    {
        var cargaHoraria = await _cargaHorariaRepository.GetCargaHoraria(id);
        return _mapper.Map<CargaHorariaDto>(cargaHoraria);
    }

    public async Task<List<CargaHorariaDto>> GetCargaHoraria(int? legajo, string proyecto, string tarea)
    {
        var cargasHorarias = await _cargaHorariaRepository.GetWithFilters(
            legajo,
            proyecto,
            tarea);
        
        return _mapper.Map<List<CargaHorariaDto>>(cargasHorarias);
    }

    public async Task<BaseResponse> UpdateCargaHoraria(UpdateCargaHorariaDto updateDto)
    {
        try
        {
            var cargaHorariaById = await _cargaHorariaRepository.GetById(updateDto.Id!);
            
            if (cargaHorariaById is null)
            {
                return new BaseResponse(false,updateDto.Id!,"NOT FOUND");
            }
            var cargaHorariaToUpdate = _mapper.Map<CargaHoraria>(updateDto);

            if (cargaHorariaToUpdate.Legajo == null)
            {
                cargaHorariaToUpdate.Legajo = cargaHorariaById.Legajo;
            }
            if (string.IsNullOrEmpty(cargaHorariaToUpdate.ProyectoId))
            {
                cargaHorariaToUpdate.ProyectoId = cargaHorariaById.ProyectoId;
            }
            if (string.IsNullOrEmpty(cargaHorariaToUpdate.TareaId))
            {
                cargaHorariaToUpdate.TareaId = cargaHorariaById.TareaId;
            }
            
            if (cargaHorariaToUpdate.Fecha is null)
            {
                cargaHorariaToUpdate.Fecha = cargaHorariaById.Fecha;
            }
            
            if (cargaHorariaToUpdate.Horas == 0)
            {
                cargaHorariaToUpdate.Horas = cargaHorariaById.Horas;
            }
            
            if (string.IsNullOrEmpty(cargaHorariaToUpdate.Descripcion))
            {
                cargaHorariaToUpdate.Descripcion = cargaHorariaById.Descripcion;
            }
            
            await _cargaHorariaRepository.Update(cargaHorariaToUpdate);
            return new BaseResponse(true, updateDto.Id!);
        }
        catch (Exception e)
        {
            return new BaseResponse(true, updateDto.Id!);
        }
    }
}