namespace Escambo.Dommain.Model;
public sealed class Conversa : BaseEntity
{
    
    public int ConversaId { get; set; }
    public DateTime DataHoraInicio { get; set; } 
    public DateTime DataHoraFim { get; set; } 

    public ICollection<Mensagem>? Mensagens { get; set; }
    public ICollection<ConversasHasUsuarios>? ConversasHasUsuarios { get; set; }
}