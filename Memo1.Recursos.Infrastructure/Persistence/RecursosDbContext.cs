using Memo1.Recursos.Domain;
using Memo1.Recursos.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Memo1.Recursos.Infrastructure.Persistence;

public class RecursosDbContext : DbContext
{
    
    public RecursosDbContext() { }
        
    public RecursosDbContext(DbContextOptions<RecursosDbContext> options) : base(options) { }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelConfig(modelBuilder);
    }
    
    
    public virtual DbSet<CargaHoraria> Cargahorarias { get; set; }

    private static void ModelConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecursosDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new CargaHorariaConfiguration());
    }
    
}