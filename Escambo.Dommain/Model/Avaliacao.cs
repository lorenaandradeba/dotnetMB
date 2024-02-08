namespace Escambo.Dommain.Model;

public sealed class Avaliacao : BaseEntity
{
    public int AvaliacaoId { get; set; }
    public string? Mensagem  { get; set; }
    public int? Estelas { get; set; }
    public ICollection<PrestacaoServicoHasAvaliacoes>? PrestacaoServicoHasAvaliacoes { get; set; }

}