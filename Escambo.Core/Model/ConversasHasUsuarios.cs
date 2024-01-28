using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Core.Model
{
    public class ConversasHasUsuarios
    {
        public int ConversasIdMensagem { get; set; }
        public int UsuariosIdUsuario { get; set; }
        public Conversa? Conversa { get; set; }
        public Usuario? Usuario { get; set; }
    }
}