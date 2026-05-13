using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //Propriedades da Entidade Users
        builder.ToTable("Users");
        builder.HasKey(c => c.Id);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
        
        //Relação da tabela Chamados com Users
        builder.HasMany(u => u.Chamados);
    }
}