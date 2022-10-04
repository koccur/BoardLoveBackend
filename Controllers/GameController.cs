using BoardLove.Services;
using BoardLove.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardLove.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    public GameController()
    {
    }

    [HttpGet]
public ActionResult<List<Game>> GetAll() =>
    GameService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
public ActionResult<Game> Get(int id)
{
    var game = GameService.Get(id);

    if(game == null)
        return NotFound();

    return game;
}

    [HttpPost]
public IActionResult Create(Game game)
{            
    // This code will save the pizza and return a result
    GameService.Add(game);
    return CreatedAtAction(nameof(Create), new { id = game.Id}, game);
}

    [HttpPut("{id}")]
public IActionResult Update(int id, Game game)
{
        if (id != game.Id){
            return BadRequest();
        }
        
           
    var existingGame = GameService.Get(id);
    if(existingGame is null){
        return NotFound();
    }
   
    GameService.Update(game);           
   
    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
        var game = GameService.Get(id);
   
    if (game is null)
        return NotFound();
       
    GameService.Delete(id);
   
    return NoContent();
}
}