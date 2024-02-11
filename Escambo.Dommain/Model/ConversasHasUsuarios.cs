using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Dommain.Model;

    public class ConversasHasUsuarios : BaseEntity
    {
        public int ConversasIdMensagem { get; set; }
        public int UsuariosIdUsuario { get; set; }
        public Conversa? Conversa { get; set; }
        public Usuario? Usuario { get; set; }
    }
