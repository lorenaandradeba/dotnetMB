namespace Escambo.Domain.Entities;
public sealed class Mensagem: BaseEntity
{
    
    public int MensagemId { get; set; }
    public string? Texto { get; set; }
    public DateTime DataEnvio { get; set; } //data de envio
    public DateTime HoraEnvio { get; set;} //hora de envio
    public int ChatId {get;set;}
    public required Chat Chat {get;set;}
}