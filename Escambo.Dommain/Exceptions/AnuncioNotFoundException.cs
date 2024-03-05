
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Dommain.Exceptions
{
    public class AnuncioNotFoundException : Exception
    {
        public AnuncioNotFoundException() :
           base("Anuncio não encontrado.")
        {
        }
    }

}
