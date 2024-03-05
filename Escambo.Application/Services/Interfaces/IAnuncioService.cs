using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.Application.Services.Interfaces
{
    public interface IAnuncioService
    {
        public List<AnuncioViewModel> GetAll();
        public AnuncioViewModel? GetById(int id);
        public int Create(AnuncioInputModel anuncio);
        public void Update(int id, AnuncioInputModel anuncio);
        public void Delete(int id);
    }
}