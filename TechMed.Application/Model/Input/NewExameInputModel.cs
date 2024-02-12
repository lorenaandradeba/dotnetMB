namespace TechMed.Application.Model.Input;
public class ExameInputModel{

    public string? Nome;
    public DateTimeOffset DataHora {get;set;}
    public decimal Valor;
    public string? Local;
    public int AtendimentoId{get;set;}
}