using Microsoft.AspNetCore.Mvc;
namespace TechMed.WebAPI.Controller;

[ApiController]
[Route("Atendimentos")]
public class AtendimentoControler: ControllerBase{

    [HttpGet ("Atenditmentos")]
    public string GetAll(){
        
        return "Hello World";
    }
}