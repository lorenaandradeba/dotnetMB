
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;

public interface IExameService
{
    int Create(int AtendimentoId, ExameInputModel exame);
    void Delete(int id);
    List<ExameViewModel> GetAll();
    ExameViewModel GetById(int id);
    void Update(int id, ExameInputModel exame);

}