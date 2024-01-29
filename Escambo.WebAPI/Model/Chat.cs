namespace Escambo.WebAPI.Model;
public sealed class Chat 
{
    
    public int ChatId { get; set; }
    public DateTime BeginDate { get; set; } //hora de incio
    public DateTime EndDate { get; set; } //hora de enceramento

    public int DestinatarioId { get; set; } //destinatario
    public required Usuario Destinatario { get; set; }
    public int RemetenteId { get; set; } //remetente
    public required Usuario Remetente { get; set; }

    ICollection<Mensagem>? Mensagens { get; set; }
}