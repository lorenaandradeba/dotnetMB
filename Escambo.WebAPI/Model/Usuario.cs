namespace Escambo.WebAPI.Model;
public sealed class Usuario
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; } //nome
    public string? Email{get;set;} //email
    public string? Senha{ get; set; } //senha
    public string? CPF {get; set;}
    public string? RG {get; set;}
    public DateTime Nascimento {get;set;} //aniversario
    public string? Endereço {get; set;} //endereço
    public int Status {get;set;} 
    public decimal Credito {get;set;} //credito

    public ICollection<PrestacaoServico> PrestacaoServiços {get;} = new List<PrestacaoServico>();
    public ICollection<Chat>? Chats { get; set; }
    public ICollection<Anuncio> Anuncios {get;} = new List<Anuncio>();
}
