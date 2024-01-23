namespace Escambo.Domain.Entities;
public sealed class Service: BaseEntity
{
    
    public int ServiceId { get; set; }
    public string? Description {get; set;} //descrição
    public string? Category {get;set;} //categoria
    public string? Type {get;set;} //tip

    public int Status {get;set;} //estatus do pedido ?
    public string? Duration {get;set;} // tempo estimado de duração

    public DateTime WorkDate {get;set;} //data para inicio

    public Decimal CreditOffer {get;set;} //troca ofertada 


    public int UserIdRequired { get; set; }//Contratante
    public required User UserRequired  { get; set; }

    public int UserIdAccepted {get;set;}//Prestador 
    public User? UserAccepted  { get; set; }
   

}