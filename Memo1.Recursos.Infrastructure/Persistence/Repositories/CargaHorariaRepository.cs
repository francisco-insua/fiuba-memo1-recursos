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

    public async Task<CargaHoraria?> GetCargaHoraria(string legajo)
    {
        return await _context.Cargahorarias
            .Where(x => x.legajo == legajo)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

}