using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class HeroisController : ControllerBase
{
    private static List<Heroi> listaDeHerois = [];

    [HttpGet]
    public ActionResult<List<Heroi>> listarHerois()
    {
        return Ok(listaDeHerois);
    }

    
}