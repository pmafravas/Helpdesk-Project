using Domain.Enums;
using Infrastructure.Identity;

namespace Domain.Entities;

public class Chamado
{
    public int ChamadoId { get; set; }
    public ApplicationUser SolicitanteId { get; private set; }
    public ApplicationUser ResponsavelId { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public List<MensagemChamado> Mensagens { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime UltimaAtividade { get; private set; }
    public DateTime? DataFinalizacao { get; private set; }
    public StatusChamado StatusChamado { get; private set; }

    public Chamado(ApplicationUser solicitanteId, ApplicationUser responsavelId, string titulo, string descricao, DateTime dataCriacao)
    {
        SolicitanteId = solicitanteId;
        ResponsavelId = responsavelId;
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = UltimaAtividade = dataCriacao;
        StatusChamado = StatusChamado.Aberto;
    }
    
    private void VerificarStatusChamado()
    {
        if (StatusChamado == StatusChamado.Cancelado)
        {
            throw new InvalidOperationException("Operação inválida, o chamado já está fechado");
        }
    }

    public void AdicionarMensagem(string mensagem, ApplicationUser usuario)
    {
        VerificarStatusChamado();
        MensagemChamado novaMensagen = new MensagemChamado(ChamadoId, mensagem, DateTime.Now, usuario);
        Mensagens.Add(novaMensagen);
        UltimaAtividade = DateTime.Now;
    }

    public void AtualizarStatus(StatusChamado novoStatus)
    {
        UltimaAtividade = DateTime.Now;
        if (novoStatus == StatusChamado.Finalizado)
        {
            DataFinalizacao = null;
        }
        StatusChamado = novoStatus;
    }
    
    
}