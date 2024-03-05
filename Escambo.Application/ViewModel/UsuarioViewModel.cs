using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public required string Nome { get; set; }
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
        
        public ICollection<AnuncioViewModel>? Anuncios { get; set; }
        public ICollection<MensagemViewModel>? Mensagens { get; set; }
        public ICollection<ConversaViewModel>? Conversas { get; set; }
    }
}
