
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Dommain.Exceptions
{
    public class UsuarioNotFoundException : Exception
    {
        public UsuarioNotFoundException() :
           base("User não encontrado.")
        {
        }
    }

}
