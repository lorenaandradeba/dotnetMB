namespace TechMed.Application.Model.View;

public class AtendimentoViewModel{
    public int AtendimentoId { get; set; }
    public DateTimeOffset DataHoraInicio { get; set; }
    public DateTimeOffset DataHoraFim { get; set; }
    public string? SuspeitaInicial { get; set; }
    public string? Diagnostico { get; set; }
    public   required MedicoViewModel? Medico { get; set; }
    public required PacienteViewModel Paciente { get; set; }
    public List<ExameViewModel>? Exames {get;set;}
}

