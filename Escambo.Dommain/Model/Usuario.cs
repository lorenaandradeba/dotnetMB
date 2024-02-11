namespace Escambo.Dommain.Model;
public sealed class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; } 
    public string? Email { get; set; }
    public string? Senha { get; set; } 
    public string? CPF { get; set; }
    public string? RG { get; set; }
    public DateTime Nascimento { get; set; } 
    public string? Endereço { get; set; } 
    public int Status { get; set; }
    public decimal Credito { get; set; } 
    public string? LinkLinkedln { get; set; }
    public string? Sobre { get; set; }

    public ICollection<Anuncio>? Anuncios { get; set; }
    public ICollection<Mensagem>? Mensagens { get; set; }
    public ICollection<PrestacaoServicoHasUsuarios>? PrestacaoServicoHasUsuarios { get; set; }
    public ICollection<ConversasHasUsuarios>? ConversasHasUsuarios { get; set; }
}
