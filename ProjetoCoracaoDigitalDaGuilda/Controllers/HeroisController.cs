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

    private static List<Heroi> listaHeroisPorNivel = [];

    [HttpGet("filtro/{nivelMinimo}")]
    public ActionResult<List<Heroi>> FiltrarHeroi(int nivelMinimo)
    {
        listaHeroisPorNivel = listaDeHerois.Where(l => l.Nivel >= nivelMinimo).ToList();

        return Ok(listaHeroisPorNivel);
    }

    static int idAtual = 1;

    [HttpPost]
    public ActionResult<Heroi> RecrutarHeroi([FromBody] Heroi novoHeroi)
    {
        if (listaDeHerois.Where(l => l.Nome.Equals(novoHeroi.Nome)).Any())
        {
            return BadRequest("Já existe um Herói com esse nome :/");
        }

        novoHeroi.Id = idAtual;
        idAtual++;

        listaDeHerois.Add(novoHeroi);
        return novoHeroi;
    }

    [HttpPut("{id}")]
    public ActionResult<Heroi> TreinarHeroi(int id, [FromBody] Heroi treinoHeroi)
    {
        Heroi? HeroiTreinado = listaDeHerois.FirstOrDefault(h => h.Id == id);

        if (HeroiTreinado is null)
        {
            return NotFound("Id do herói não encontrado.");
        }

        HeroiTreinado.Id = id;
        HeroiTreinado.Nome = treinoHeroi.Nome;
        HeroiTreinado.Classe = treinoHeroi.Classe;
        HeroiTreinado.Nivel = treinoHeroi.Nivel;

        return HeroiTreinado;
    }

    [HttpDelete("{id}")]
    public ActionResult<string> EliminarHeroi(int id)
    {
        Heroi? HeroiRemovido = listaDeHerois.FirstOrDefault(h => h.Id == id);
        if (HeroiRemovido is null)
        {
            return NotFound("Id do herói não encontrado.");
        }

        listaDeHerois.Remove(HeroiRemovido);

        return NoContent();
    }
}