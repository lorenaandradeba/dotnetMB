using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.ViewModels
{
    public class AnuncioViewModel
    {
        public int AnuncioId { get; set; }
        public  string? NomeServico { get; set; }
        public string? Descricao { get; set; }
        public decimal? Creditos { get; set; }
        public string? Categoria { get; set; }
        public string? Tipo { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioViewModel? Usuario { get; set; }
    }
}
