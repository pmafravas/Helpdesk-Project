using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ChamadoConfiguration : IEntityTypeConfiguration<Chamado>
{
    public void Configure(EntityTypeBuilder<Chamado> builder)
    {
        //Propriedades das variáveis com Constraints
        builder.ToTable("Chamados");
        builder.HasKey(c => c.ChamadoId);
        builder.HasOne(c => c.SolicitanteId);
        builder.HasOne(c => c.ResponsavelId);
        builder.HasMany(c => c.Mensagens);
        
        //Propriedades das variáveis do Chamado
        builder.Property(c => c.Titulo).IsRequired().HasMaxLength(80).HasColumnType("varchar(80)");
        builder.Property(c => c.Descricao).IsRequired().HasMaxLength(2000).HasColumnType("varchar(2000)");
        builder.Property(c => c.DataCriacao).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.UltimaAtividade).HasColumnType("datetime");
        builder.Property(c => c.DataFinalizacao).HasColumnType("datetime");
        builder.Property(c => c.StatusChamado).IsRequired();
    }
}