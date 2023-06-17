namespace Memo1.Recursos.Application.Dtos.CargaHorarias;

public class CreateCargaHorariaDto
{
    public string legajo { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string proyecto { get; set; }
    public string tarea { get; set; }
    public DateOnly fecha { get; set; }
    public int horas { get; set; }
}