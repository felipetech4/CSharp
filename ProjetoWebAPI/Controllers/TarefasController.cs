using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TarefasController: ControllerBase
{
    private static readonly List<Tarefa> listaDeTarefas = [];
    private static int idAtual = 1;

    [HttpGet("listar")]
    public ActionResult<List<Tarefa>> ListarTarefas()
    {
        return Ok(listaDeTarefas);
    }

    [HttpPost("incluir")]
    public ActionResult<Tarefa> IncluirTarefas([FromBody] Tarefa novaTarefa)
    {
        if(listaDeTarefas.Where(w => w.Nome.Equals(novaTarefa.Nome)).Any())
        {
            return BadRequest("Já existe uma tarefa com esse nome.");
        }

        novaTarefa.Id = idAtual;
        idAtual++;

        listaDeTarefas.Add(novaTarefa);
        return novaTarefa;
    }
}


public class Tarefa
{
    public int Id{get;set;}
    public string Nome{get;set;} = string.Empty;
    public bool Concluida{get;set;}
}

