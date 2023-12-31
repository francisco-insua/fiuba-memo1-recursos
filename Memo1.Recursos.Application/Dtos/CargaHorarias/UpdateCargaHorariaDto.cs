﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Memo1.Recursos.Application.Dtos.CargaHorarias;

public class UpdateCargaHorariaDto
{
    [Required(ErrorMessage = "The field is required")]
    public string? Id { get; set; }

    public int? Legajo { get; set; }
   
    public string ProyectoId { get; set; }
    
    public string TareaId { get; set; }
    
    public DateOnly? Fecha { get; set; }
    
    [DefaultValue(0)]
    public int Horas { get; set; }
    public string Descripcion { get; set; }
}