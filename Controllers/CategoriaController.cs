using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class CategoriaController: ControllerBase{
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService categoriaService){
        this.categoriaService = categoriaService;
    }    
    
    [HttpGet]
    public IActionResult Get(){

        return Ok(categoriaService.Get());
    } 

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria){

        if(categoriaService.Save(categoria) == null){
            return Conflict();
        }

        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Categoria categoria){

        if(categoriaService.Update(categoria) == null){
            return Conflict();
        }

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){

        categoriaService.Detelete(id);
        return Ok();
    }


}