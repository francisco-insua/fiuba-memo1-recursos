using Memo1.Recursos.Domain;

namespace Memo1.Recursos.Application.Contracts.Repositories;

public interface ICargaHorariaRepository
{
    Task Add(CargaHoraria cargaHoraria);
    Task Delete(string id);
    Task<CargaHoraria?> GetCargaHoraria(string id);
    Task<List<CargaHoraria>> GetWithFilters(string legajo, string proyecto, string tarea);
    Task<CargaHoraria?> GetById(string id);
    Task Update(CargaHoraria cargaHoraria);
}