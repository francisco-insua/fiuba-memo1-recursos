﻿using Memo1.Recursos.Application.Contracts.Services;
using Memo1.Recursos.Application.Dtos.CargaHorarias;
using Memo1.Recursos.Application.Responses;
using Memo1.Recursos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Memo1.Recursos.API.Controllers.V1;

[Route("api/v1/cargahoraria")]
[ApiController]
public class CargaHorariaController : Controller
{

    private readonly ICargaHorariaService _cargaHorariaService;

    public CargaHorariaController(ICargaHorariaService commentService)
    {
        _cargaHorariaService = commentService;
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
    
    
    /*Obtiene horas cargadas por legajo de recurso*/
    [HttpGet(template: "{legajo}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CargaHorariaDto>> getCargaHoraria(string legajo)
    {
        var horas = await _cargaHorariaService.GetCargaHoraria(legajo);
        return horas is not null ? Ok(horas) : NotFound(legajo);
    }
    
    /*Obtiene horas cargadas por id de tarea
    [HttpGet(template: "{tarea}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CargaHorariaDto>> getCargaHoraria(string tarea)
    {
        var horas = await _cargaHorariaService.GetCargaHoraria(tarea);
        return horas is not null ? Ok(horas) : NotFound(tarea);
    }
    
    */
}