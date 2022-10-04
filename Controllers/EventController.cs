using BoardLove.Services;
using BoardLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardLove.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    public EventController()
    {
    }

    [HttpGet]
public ActionResult<List<EventGame>> GetAll() =>
    EventService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
public ActionResult<EventGame> Get(int id)
{
    var eventGame = EventService.Get(id);

    if(eventGame == null)
        return NotFound();

    return eventGame;
}

    [HttpPost]
public IActionResult Create(EventGame eventGame)
{            
    // This code will save the pizza and return a result
    EventService.Add(eventGame);
    return CreatedAtAction(nameof(Create), new { id = eventGame.Id}, eventGame);
}

    [HttpPut("{id}")]
public IActionResult Update(int id, EventGame eventGame)
{
        if (id != eventGame.Id){
            return BadRequest();
        }
        
           
    var existingGame = EventService.Get(id);
    if(existingGame is null){
        return NotFound();
    }
   
    EventService.Update(eventGame);           
   
    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
        var eventGame = EventService.Get(id);
   
    if (eventGame is null)
        return NotFound();
       
    EventService.Delete(id);
   
    return NoContent();
}
}