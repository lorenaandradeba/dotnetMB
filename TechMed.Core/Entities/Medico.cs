namespace TechMed.Core.Entities;


public class Medico:Pessoa {
    //Nome e cpf do Medico em Pessoa
    public int MedicoId { get; set; }
    public required string CRM {get;set;}

    public ICollection<Atendimento>? Atendimentos { get; set; }
    // public ICollection<Exame>? Exames {get; set;}
}