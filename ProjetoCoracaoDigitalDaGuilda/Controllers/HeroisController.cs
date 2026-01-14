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

    private static List<string> listaDeApresentacoes = [];

    [HttpGet("apresentacoes")]
    public ActionResult<List<string>> apresentarHerois()
    {
        foreach (var heroi in listaDeHerois)
        {
            listaDeApresentacoes.Add(heroi.Apresentar());
        }

        return listaDeApresentacoes;
    }
}