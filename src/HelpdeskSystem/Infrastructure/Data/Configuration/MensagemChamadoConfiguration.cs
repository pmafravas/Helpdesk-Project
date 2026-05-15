using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class MensagemChamadoConfiguration : IEntityTypeConfiguration<MensagemChamado>
{
    public void Configure(EntityTypeBuilder<MensagemChamado> builder)
    {
        //Propriedades da entidade MensagemChamado
        builder.ToTable("Mensagens");
        builder.HasKey(c => c.MensagemId);
        builder.HasOne(c => c.Chamado).WithMany(u => u.Mensagens).HasForeignKey(c => c.ChamadoAssociado).OnDelete(DeleteBehavior.Restrict);
        builder.Property(c => c.Mensagem).HasColumnName("ConteudoMensagem").HasColumnType("varchar").HasMaxLength(2000).IsRequired();
        builder.Property(c => c.DataCriacao).IsRequired();
        builder.Property(c => c.Editado).IsRequired();
        builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(c => c.UsuarioDono).OnDelete(DeleteBehavior.Restrict);
    }
}