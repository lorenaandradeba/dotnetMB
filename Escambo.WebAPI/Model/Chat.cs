namespace Escambo.Domain.Entities;
public sealed class Chat : BaseEntity
{
    
    public int ChatId { get; set; }
    public DateTime BeginDate { get; set; } //hora de incio
    public DateTime EndDate { get; set; } //hora de enceramento

    public int SenderId { get; set; } //remetente
    public required User Sender { get; set; }
    public int ReceiverId { get; set; } //destinatario
    public required User Receiver { get; set; }

    ICollection<Message>? Messages { get; set; }
}