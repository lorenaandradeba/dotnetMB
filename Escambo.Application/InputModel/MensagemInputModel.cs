using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.InputModels
{
    public class MensagemInputModel
    {
        public string? Texto { get; set; }
        
        public int UsuariosIdUsuario { get; set; }
        public int ConversasIdMensagem { get; internal set; }
    }
}
