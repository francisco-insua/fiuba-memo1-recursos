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
        builder.Property(t => t.legajo).HasColumnName("legajo");
        builder.Property(t => t.nombre).HasColumnName("nombre");
        builder.Property(t => t.apellido).HasColumnName("apellido");
        builder.Property(t => t.proyecto).HasColumnName("proyecto");
        builder.Property(t => t.tarea).HasColumnName("tarea");
        builder.Property(t => t.fecha).HasColumnName("fecha");
        builder.Property(t => t.horas).HasColumnName("horas");
    }
}