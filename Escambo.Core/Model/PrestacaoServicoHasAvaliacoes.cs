using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Core.Model
{
    public class PrestacaoServicoHasAvaliacoes
    {
        public int PrestacaoServicoIdPrestacaoServico { get; set; }
        public int AvaliacoesIdAvaliacoes { get; set; }
        public PrestacaoServico? PrestacaoServico { get; set; }
        public Avaliacao? Avaliacoes { get; set; }
    }
}