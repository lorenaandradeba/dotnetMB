using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.InputModels
{
    public class UsuarioInputModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public DateTime Nascimento { get; set; }
        public string? Endereço { get; set; }
        public int Status { get; set; }
        public decimal Credito { get; set; }
        public string? LinkLinkedln { get; set; }
        public string? Sobre { get; set; }
    }
}
