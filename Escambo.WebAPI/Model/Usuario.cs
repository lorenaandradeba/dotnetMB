namespace Escambo.Domain.Entities;
public sealed class Usuario: BaseEntity 
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; } //nome
    public required string? Email{get;set;} //email
    public required string Senha{ get; set; } //senha
    public required string? CPF {get; set;}
    public required string? RG {get; set;}
    public DateTime Nascimento {get;set;} //aniversario
    public string? Endereço {get; set;} //endereço
    public int Status {get;set;} 
    public decimal Credito {get;set;} //credito
    public ICollection<Advertisement> Anúncios {get;} = new List<Advertisement>();
    public ICollection<Avaluation>? Avaliação { get; set; } //Avaliações como avaliador

}
