using System.Security.Cryptography.X509Certificates;
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
    public ActionResult<Tarefa> IncluirTarefa([FromBody] Tarefa novaTarefa)
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

    [HttpPut("alterar")]
    public ActionResult<Tarefa> AlterarTarefa([FromBody] Tarefa tarefaAlterada)
    {
        Tarefa? tarefaParaAlterar = listaDeTarefas.FirstOrDefault(t => t.Id == tarefaAlterada.Id);
        if(tarefaParaAlterar is null)
        {
            return NotFound("Id da tarefa não encontrado.");
        }

        tarefaParaAlterar.Nome = tarefaAlterada.Nome;
        tarefaParaAlterar.Concluida = tarefaAlterada.Concluida;

        return tarefaAlterada;
    }
    
    [HttpDelete("deletar/{id}")]
    public ActionResult DeletarTarefa(int id)
    {
        Tarefa? tarefaParaExcluir = listaDeTarefas.FirstOrDefault(t => t.Id == id);

        if(tarefaParaExcluir is null)
        {
            return NotFound("Id da tarefa não encontrado.");
        }

        listaDeTarefas.Remove(tarefaParaExcluir);

        return NoContent();
    }
}


public class Tarefa
{
    public int Id{get;set;}
    public string Nome{get;set;} = string.Empty;
    public bool Concluida{get;set;}
}

