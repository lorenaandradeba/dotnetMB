namespace Escambo.Domain.Entities;

public sealed class Avaluation: BaseEntity //avaliação
{
    public int AvaluationId { get; set; }
    // anuncio referencia para o entity criar o relacionamento
    public int PosterId { get; set; } 
    public required Poster Poster { get; set; } 

    //Usuario Avaliador
    public int AvaliadorId { get; set; }
    public required User Avaliador { get; set; }

    //Usuario Avaliado
    public int AvaliadoId { get; set; }
    public required User Avaliado { get; set; }

    // estrelas
    public int Star { get; set; }

    //comentario
    public string? Comment { get; set; }
 
}