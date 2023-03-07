using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class TareaController: ControllerBase{
    ITareaService tareaService;

    public TareaController(ITareaService tareaService){
        this.tareaService = tareaService;
    }    
    
    [HttpGet]
    public IActionResult Get(){

        return Ok(tareaService.Get());
    } 

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea){

        if(tareaService.Save(tarea) == null){
            return Conflict();
        }

        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Tarea tarea){

        if(tareaService.Update(tarea) == null){
            return Conflict();
        }

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){

        tareaService.Detelete(id);
        return Ok();
    }


}