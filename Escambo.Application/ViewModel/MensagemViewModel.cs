using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.ViewModels
{
    public class MensagemViewModel
    {
        public int MensagemId { get; set; }
        public string? Texto { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime HoraEnvio { get; set; }
        public int ConversaId { get; set; }
        public int UsuariosIdUsuario { get; set; }
        public UsuarioViewModel? Usuario { get; set; }
    }
}
