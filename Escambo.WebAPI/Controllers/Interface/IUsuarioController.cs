using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers.Interface;
public interface IUsuarioController:IGenericController<UsuarioViewModel, UsuarioInputModel> {}
