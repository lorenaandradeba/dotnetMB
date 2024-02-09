
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;

namespace TechMed.Application.Service.Interface;

public interface IPacienteService{ 
    public List<PacienteViewModel> GetAll();
    public PacienteViewModel? GetById(int id);
    public int Create(PacienteInputModel paciente);
    public void Update(int id, PacienteInputModel paciente);
    public void Delete(int id); 
}