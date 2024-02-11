namespace TechMed.Application.Service.Interface;

public interface IGenericService<TInputModel, TViewModel>{
    public List<TViewModel> GetAll();
    public TViewModel GetById(int id);
    public int Create(TInputModel Enity);
    public void Update(int id, TInputModel Entity);

    public void Delete(int id);

}

//  public List<MedicoViewModel> GetAll();
   
//     public MedicoViewModel? GetById(int id);
//     public int Create(MedicoInputModel medico);
    // public void Delete(int id);