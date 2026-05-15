using Infrastructure.Identity;

namespace Domain.Entities;

public class MensagemChamado
{
    public int MensagemId { get; private set; }
    public int ChamadoAssociado { get; private set; }
    public string Mensagem { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public Guid UsuarioDono { get; private set; }
    public bool Editado { get; private set; }
    
    //Propriedades para o EF carregar a relação
    public Chamado Chamado { get; private set; }
    public ApplicationUser Autor { get; private set; } = null!;

    
    public MensagemChamado() { }
    public MensagemChamado(int chamadoAssociado, string mensagem, DateTime dataCriacao, Guid usuario)
    {
        ChamadoAssociado = chamadoAssociado;
        Mensagem = mensagem;
        DataCriacao = dataCriacao;
        UsuarioDono = usuario;
        Editado = false;
    }

    public void EditarMensagem(string novaMensagem)
    {
        TimeSpan tempoPassado = DataCriacao - DateTime.Now;
        if (tempoPassado.TotalMinutes > 30)
            throw new InvalidOperationException("O tempo limite para edição de mensagem já foi excedido");
        if (string.IsNullOrEmpty(novaMensagem) || string.IsNullOrWhiteSpace(novaMensagem))
            throw new InvalidOperationException("A mensagem não pode estar em branco");
        
        Mensagem = novaMensagem;
        Editado = true;
    }
}