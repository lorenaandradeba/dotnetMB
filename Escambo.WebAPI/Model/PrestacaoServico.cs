namespace Escambo.WebAPI.Model;
public sealed class PrestacaoServico
{
    
    public int ServiçoId { get; set; }
    public string? Descrição{get; set;} //descrição
    public string? Categoria {get;set;} //categoria
    public string? Tipo {get;set;} //tip

    public int Status {get;set;} //estatus do pedido ?
    public string? Duração {get;set;} // tempo estimado de duração

    public DateTime Data {get;set;} //data para inicio

    public Decimal Credito {get;set;} //troca ofertada 


    public int ContratanteId { get; set; }//Contratante
    public  Usuario? Contratante  { get; set; }//Contratante

    public int PrestadorId {get;set;}//Prestador 
    public Usuario? Prestador { get; set; }

    public ICollection<Avaliacao> Avaliacoes {get;} = new List<Avaliacao>();
   
}