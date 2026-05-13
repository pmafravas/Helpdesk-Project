using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MensagemChamadoConfiguration
{
    public void Configure(EntityTypeBuilder<MensagemChamado> builder)
    {
        //Propriedades da entidade MensagemChamado
        builder.ToTable("Mensagens");
        builder.HasKey(c => c.MensagemId);
        builder.Property(c => c.ChamadoAssociado).IsRequired();
        builder.Property(c => c.Mensagem).HasColumnName("ConteudoMensagem").HasColumnType("varchar").HasMaxLength(2000).IsRequired();
        builder.Property(c => c.DataCriacao).IsRequired();
        builder.Property(c => c.Editado).IsRequired();
        
        //Relação com tabela Usuario
        builder.HasOne(c => c.UsuarioDono);
    }
}