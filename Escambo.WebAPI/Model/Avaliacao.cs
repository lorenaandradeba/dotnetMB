namespace Escambo.WebAPI.Model;

public sealed class Avaliacao//avaliação
{
    public int AvaliacaoId { get; set; }
    // anuncio referencia para o entity criar o relacionamento
    public int PrestacaoServicoId { get; set; } 
    public required PrestacaoServico PrestacaoServico { get; set; } 

    //Usuario Avaliador
    public int AvaliadorId { get; set; }
    public required Usuario Avaliador { get; set; }

    //Usuario Avaliado
    public int AvaliadoId { get; set; }
    public required Usuario Avaliado { get; set; }

    // estrelas
    public int Star { get; set; }

    //comentario
    public string? Comment { get; set; }
 
}