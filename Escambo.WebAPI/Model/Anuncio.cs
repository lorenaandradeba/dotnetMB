using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.WebAPI.Model
{
    public class Anuncio //Tabela Anuncio 
    {
        public int AnuncioId { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Creditos { get; set; }
        public string? Categoria { get; set; }
        public string? Tipo { get; set; }
        
        public required Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}