using Memo1.Recursos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Memo1.Recursos.Infrastructure.Persistence.Configurations;

public class CargaHorariaConfiguration : IEntityTypeConfiguration<CargaHoraria>
{
    public void Configure(EntityTypeBuilder<CargaHoraria> builder)
    {
        builder.ToTable("tbl_carga_horaria").HasKey(x => x.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.Legajo).HasColumnName("legajo");
        builder.Property(t => t.ProyectoId).HasColumnName("proyecto");
        builder.Property(t => t.TareaId).HasColumnName("tarea");
        builder.Property(t => t.Fecha).HasColumnName("fecha");
        builder.Property(t => t.Horas).HasColumnName("horas");
    }
}