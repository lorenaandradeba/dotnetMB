using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Dommain.Model;

public class PrestacaoServicoHasAvaliacoes : BaseEntity
{
    public int PrestacaoServicoIdPrestacaoServico { get; set; }
    public int AvaliacoesIdAvaliacoes { get; set; }
    public PrestacaoServico? PrestacaoServico { get; set; }
    public Avaliacao? Avaliacoes { get; set; }
}
