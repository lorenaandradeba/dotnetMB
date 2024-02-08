using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.ViewModels
{
    public class AvaliacaoViewModel
    {
        public int AvaliacaoId { get; set; }
        public string? Mensagem { get; set; }
        public int? Estelas { get; set; }
    }
}
