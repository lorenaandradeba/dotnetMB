
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IUserService
    {
        
      public List<UserViewModel> GetAll();
      public UserViewModel? GetById(int id);
      public int Create(NewUserInputModel user);
      public void AdicionaSistemaAoUser(int userId, int sistemaId);
      public void Update(int id, NewUserInputModel user);
      public void Delete(int id);
    }
}