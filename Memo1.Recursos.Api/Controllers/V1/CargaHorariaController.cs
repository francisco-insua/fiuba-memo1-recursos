using Memo1.Recursos.Application.Contracts.Services;
using Memo1.Recursos.Application.Dtos.CargaHorarias;
using Memo1.Recursos.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Memo1.Recursos.API.Controllers.V1;

[Route("api/v1/carga-horaria")]
[ApiController]
public class CargaHorariaController : Controller
{

    private readonly ICargaHorariaService _cargaHorariaService;

    public CargaHorariaController(ICargaHorariaService cargaHorariaService)
    {
        _cargaHorariaService = cargaHorariaService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse>> CreateCargaHoraria([FromBody] CreateCargaHorariaDto createCargaHorariaDto)
    {
        var response = await _cargaHorariaService.CreateCargaHoraria(createCargaHorariaDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse>> DeleteCargaHoraria(string id)
    {
        var response = await _cargaHorariaService.DeleteCargaHoraria(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CargaHorariaDto>> GetCargasHorariasById(string id) 
    {
        var cargaHoraria = await _cargaHorariaService.GetCargaHoraria(id);
        return cargaHoraria is not null ? Ok(cargaHoraria) : NotFound(id);
    }
    
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<CargaHorariaDto>>> GetCargasHorariasConFiltros(
        [FromQuery] int? legajo = null,
        [FromQuery] string proyecto = "",
        [FromQuery] string tarea = "") 
    {
        return await _cargaHorariaService.GetCargaHoraria(legajo, proyecto, tarea);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse>> UpdateCargaHoraria([FromBody] UpdateCargaHorariaDto updateDto)
    {
        var response =  await _cargaHorariaService.UpdateCargaHoraria(updateDto);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}