using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.ViewModels
{
    public class PrestacaoServicoViewModel
    {
        public int PrestacaoServicoId { get; set; }
        public int ServiçoId { get; set; }
        public string? Descrição { get; set; }
        public string? Categoria { get; set; }
        public string? Tipo { get; set; }
        public int Status { get; set; }
        public string? Duração { get; set; }
        public DateTime Data { get; set; }
        public Decimal Credito { get; set; }
        public int ContratanteId { get; set; }
        public int PrestadorId { get; set; }
        public int AnuncioIdAnuncio { get; set; }
        public ICollection<AvaliacaoViewModel>? Avaliacoes { get; set; }
        public ICollection<UsuarioViewModel>? Usuarios { get; set; }
    }
}
