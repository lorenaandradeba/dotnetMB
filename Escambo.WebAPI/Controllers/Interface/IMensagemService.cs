using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.WebAPI.Controllers.Interface;

public interface IMensagemController:IGenericController<MensagemViewModel, MensagemInputModel>
{
    
}