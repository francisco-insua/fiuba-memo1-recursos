namespace Memo1.Recursos.Domain;

public record CargaHoraria
{
    public string Id { get; set; }
    public string Legajo { get; set; }
    public string ProyectoId { get; set; }
    public string TareaId { get; set; }
    public DateOnly? Fecha { get; set; }
    public int Horas {get; set;}
    public string Descripcion { get; set; }
}