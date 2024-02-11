namespace TechMed.Application.Model.View;

public class AtendimentoViewModel{
    public int AtendimentoId { get; set; }
    public DateTimeOffset DataHoraInicio { get; set; }
    public DateTimeOffset DataHoraFim { get; set; }
    public string? SuspeitaInicial { get; set; }
    public string? Diagnostico { get; set; }
    public  MedicoViewModel? Medico { get; set; }
    public  PacienteViewModel? Paciente { get; set; }
    
}

