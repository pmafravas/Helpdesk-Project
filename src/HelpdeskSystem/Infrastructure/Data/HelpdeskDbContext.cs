using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class HelpdeskDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options) : base(options) { }

    public DbSet<ApplicationUser> User { get; set; }
    public DbSet<Chamado> Chamados { get; set; }
    public DbSet<MensagemChamado> MensagensChamados { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(HelpdeskDbContext).Assembly);
    }
}