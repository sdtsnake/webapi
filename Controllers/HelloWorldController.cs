using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase{

    IHelloWorldService hellowWorldService;

    public HelloWorldController(IHelloWorldService hellowWorldService){
        this.hellowWorldService = hellowWorldService;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(hellowWorldService.GetHellowWorld());
    }
}