namespace Escambo.Core.Model;
public sealed class Mensagem
{

    public int MensagemId { get; set; }
    public string? Texto { get; set; }
    public DateTime DataEnvio { get; set; } //data de envio
    public DateTime HoraEnvio { get; set; } //hora de envio
    public int ConversaId { get; set; }
    public int ConversasIdMensagem { get; set; }
    public int UsuariosIdUsuario { get; set; }
    public Conversa? Conversa { get; set; }
    public Usuario? Usuario { get; set; }
}