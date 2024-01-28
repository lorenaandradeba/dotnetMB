namespace Escambo.Core.Model;
public sealed class Conversa
{
    
    public int ConversaId { get; set; }
    public DateTime DataHoraInicio { get; set; } //hora de incio
    public DateTime DataHoraFim { get; set; } //hora de enceramento

    // public int DestinatarioId { get; set; } //destinatario
    // public required Usuario Destinatario { get; set; }
    // public int RemetenteId { get; set; } //remetente
    // public required Usuario Remetente { get; set; }

    public ICollection<Mensagem>? Mensagens { get; set; }
    public ICollection<ConversasHasUsuarios>? ConversasHasUsuarios { get; set; }
}