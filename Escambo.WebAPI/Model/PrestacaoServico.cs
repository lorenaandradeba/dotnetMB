namespace Escambo.WebAPI.Model;
public sealed class PrestacaoServico
{
    public int PrestacaoId { get; set; }
    public int AnuncioId { get; set; }
    public int Status {get;set;} //estatus do pedido ?
    public string? Duração {get;set;} // tempo estimado de duração

    public required DateTime DataInicio {get;set;} 
    public DateTime? DataTermino {get;set;} 

    public decimal Credito {get;set;} //troca ofertada 


    public int ContratanteId { get; set; }//Contratante
    public  Usuario Contratante  { get; set; }//Contratante

    public int PrestadorId {get;set;}//Prestador 
    public Usuario Prestador { get; set; }

    public ICollection<Avaliacao> Avaliacoes {get;} = new List<Avaliacao>();
   
}