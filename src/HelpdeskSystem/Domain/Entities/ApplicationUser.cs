using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Nome { get; private set; }
    public Cargo Cargo { get; private set; }
    
    //Lista de chamados abertos pelo User - Instanciar aqui vai facilitar a listagem no Front-End
    public IReadOnlyCollection<Chamado> ChamadosAbertos { get; private set; }
    public IReadOnlyCollection<Chamado> ChamadosAtribuidos { get; private set; }
}