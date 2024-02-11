using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Core.Entities;

namespace TechMed.Application.Service.Interface;

public interface IMedicoService:IGenericService<MedicoInputModel, MedicoViewModel> {
    
}