
using Microsoft.AspNetCore.Mvc;
namespace Escambo.WebAPI.Controllers.Interface;
public interface IGenericController<TViewModel, TInputModel>
{


    [HttpPost]   
    public IActionResult Create(TInputModel input);

    [HttpGet]
    public IActionResult GetAll();

    [HttpGet]
    public IActionResult GetById(int id); 

    [HttpPut]
    public IActionResult Update(int id, TInputModel input);

    [HttpDelete]
    public IActionResult Delete(int id);
}

