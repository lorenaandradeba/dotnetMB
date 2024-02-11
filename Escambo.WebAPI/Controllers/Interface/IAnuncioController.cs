using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.WebAPI.Controllers.Interface;

public interface IAnuncioController:IGenericController<AnuncioViewModel, AnuncioInputModel>
{
    
}