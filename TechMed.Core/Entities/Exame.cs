namespace TechMed.Core.Entities;

public class Exame:BaseEntity
{
    public int ExameId {get; set;}
    public DateTimeOffset DataHora {get; set;}
    public string? Local {get; set;}
     
    public int AtendimentoId { get; set; }
    public required Atendimento Atendimento { get; set; }
}