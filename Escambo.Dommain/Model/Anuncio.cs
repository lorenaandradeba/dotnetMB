using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Dommain.Model;

public class Anuncio : BaseEntity
{
    public int AnuncioId { get; set; }
    public required string NomeServico { get; set; }
    public string? Descricao { get; set; }
    public decimal? Creditos { get; set; }
    public string? Categoria { get; set; }
    public string? Tipo { get; set; }

    public required Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }

    public ICollection<PrestacaoServico>? PrestacaoServicos { get; set; }
}
