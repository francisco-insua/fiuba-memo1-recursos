namespace Memo1.Recursos.Domain;

public record CargaHoraria
{
    public string Id { get; set; }
    public string legajo { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string proyecto { get; set; }
    public string tarea { get; set; }
    public DateOnly fecha { get; set; }
    public int horas {get; set;}
    
    
}