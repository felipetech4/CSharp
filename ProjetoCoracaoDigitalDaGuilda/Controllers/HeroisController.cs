using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class HeroisController : ControllerBase
{
    private static List<Heroi> listaDeHerois = [];

    [HttpGet]
    public ActionResult<List<Heroi>> ListarHerois()
    {
        return Ok(listaDeHerois);
    }

    private List<string> listaDeApresentacoes = [];

    [HttpGet("apresentacoes")]
    public ActionResult<List<string>> ApresentarHerois()
    {
        foreach (var heroi in listaDeHerois)
        {
            listaDeApresentacoes.Add(heroi.Apresentar());
        }

        return listaDeApresentacoes;
    }
}