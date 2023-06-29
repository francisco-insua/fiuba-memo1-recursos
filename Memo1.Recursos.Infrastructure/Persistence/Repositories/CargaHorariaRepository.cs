using LinqKit;
using Memo1.Recursos.Application.Contracts.Repositories;
using Memo1.Recursos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memo1.Recursos.Infrastructure.Persistence.Repositories;

public class CargaHorariaRepository : ICargaHorariaRepository
{
    protected readonly RecursosDbContext _context;

    public CargaHorariaRepository(RecursosDbContext context)
    {
        _context = context;
    }

    public async Task Add(CargaHoraria cargaHoraria)
    {
        await _context.Cargahorarias.AddAsync(cargaHoraria);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(string id)
    {
        var cargaHoraria = await _context.Cargahorarias.FindAsync(id);
        if (cargaHoraria is null)
        {
            return;
        }

        _context.Cargahorarias.Remove(cargaHoraria);
        await _context.SaveChangesAsync();
    }

    public async Task<CargaHoraria?> GetCargaHoraria(string id)
    {
        return await _context.Cargahorarias
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<List<CargaHoraria>> GetWithFilters(int? legajo, string proyecto, string tarea)
    {
        var filters = PredicateBuilder.New<CargaHoraria>();
        var filtered = false;
        
        if (legajo != null)  
        {  
            filters = filters.And(x => x.Legajo == legajo);
            filtered = true;
        } 
        
        if (!string.IsNullOrEmpty(proyecto))  
        {  
            filters = filters.And(x => x.ProyectoId == proyecto);
            filtered = true;
        }
        
        if (!string.IsNullOrEmpty(tarea))  
        {  
            filters = filters.And(x => x.TareaId == tarea);
            filtered = true;
        }
        
        if (!filtered)
        {
            return await _context.Cargahorarias
                .AsNoTracking()
                .ToListAsync();
        } 
        
        return await _context.Cargahorarias
            .Where(filters)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<CargaHoraria?> GetById(string id)
    {
        return await _context.Cargahorarias
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task Update(CargaHoraria cargaHoraria)
    {
        _context.Update(cargaHoraria);
        await _context.SaveChangesAsync();
    }
}