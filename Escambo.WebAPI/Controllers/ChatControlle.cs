using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v0.1/")]
public class ChatControlle : ControllerBase
{

    List<Chat> Chats = new List<Chat>();
    [HttpGet]
    [Route("Chat/{id}")]

    public IActionResult Get(int id){

        var chat = Chats.FirstOrDefault(u => u.ChatId == id);
        if (chat == null){
            return NoContent();
        }else{
            return Ok(chat.ToString());
        }
    }

    [HttpPost]
    [Route("Chat/")]
    public IActionResult Post([FromBody] Chat chat)
    {
        Chats.Add(chat);
        return Ok();
    }

    [HttpDelete]
    [Route("Chat/")]
    public IActionResult Delete(int id)
    {
        var chat = Chats.FirstOrDefault(u => u.ChatId == id);
        if (chat == null){
            return NotFound();
        }else
        {
            Chats.Remove(chat);
            return Ok();
        }
    }

    [HttpGet]
    [Route("Chats/{id}/usuario")]
    public IActionResult GetChatUsuariol(int id){
        var chat = Chats.FirstOrDefault(u => u.RemetenteId == id);
        if (chat == null){

            chat = Chats.FirstOrDefault(u => u.DestinatarioId == id); 
            if (chat == null){
                return NotFound();
            }else{
                return Ok(chat.ToString());
            }
            
        }else{
            return Ok(chat.ToString());
        }

    }
}