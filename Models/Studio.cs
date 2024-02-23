using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Models;

namespace dotnetMB.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Site { get; set; }
        public ICollection<Movie>? Movies { get; set; } = new List<Movie>();
    }
}