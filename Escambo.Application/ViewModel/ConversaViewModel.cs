using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.ViewModels
{
    public class ConversaViewModel
    {
        public int ConversaId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public ICollection<MensagemViewModel>? Mensagens { get; set; }
        public ICollection<UsuarioViewModel>? Usuarios { get; set; }
    }
}
