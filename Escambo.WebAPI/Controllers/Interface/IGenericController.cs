
using Microsoft.AspNetCore.Mvc;
namespace Escambo.WebAPI.Controllers.Interface;
public interface GenericController<TViewModel, TInputModel>
{

    public List<TViewModel> TEntity { get; set; }
    public IActionResult Create(TInputModel input);
    public IActionResult GetAll();
    public IActionResult GetById(int id); 
    public IActionResult Update(int id, TInputModel input);
    void Delete(int id);
}