using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escambo.Domain.Entities
{
    public class Advertisement //Tabela Anuncio 
    {
        public int AdvertisementId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Credit { get; set; }
        public string? Category { get; set; }
        public string? Type { get; set; }
        
        public required User User { get; set; }
        public int UserId { get; set; }
    }
}