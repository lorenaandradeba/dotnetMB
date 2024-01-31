namespace TechMed.Core.Entities;

public class Paciente:Pessoa
{
    //Nome e cpf do paciente em Pessoa
    public int PacienteId { get; set; }
    public DateTimeOffset DataNascimento {get; set;}

    public ICollection<Atendimento>? Atendimentos { get; set; }

}