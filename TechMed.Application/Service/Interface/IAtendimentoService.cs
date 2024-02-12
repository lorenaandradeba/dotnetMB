using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Core.Entities;

namespace TechMed.Application.Service.Interface;

public interface IAtendimentoService {
    public List<AtendimentoViewModel> GetAll();

    public AtendimentoViewModel GetById(int id);
    public int Create(AtendimentoInputModel Enity);
    public void Update(int id, AtendimentoInputModel Entity);

    public void Delete(int id);

    

}