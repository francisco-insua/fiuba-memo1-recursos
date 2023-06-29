namespace Memo1.Recursos.Application.Dtos.CargaHorarias;

public class CargaHorariaDto
{
    public string Id { get; set; }
    public int Legajo { get; set; }
    public string ProyectoId { get; set; }
    public string TareaId { get; set; }
    public DateOnly Fecha { get; set; }
    public int Horas { get; set; }
    public string Descripcion { get; set; }
}