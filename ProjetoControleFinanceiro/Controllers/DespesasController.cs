using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("api/[controller]")]

public class DespesasController: ControllerBase
{
    private static readonly List<Despesa> listaDeDespesas = [];
    private static int IdAtual = 1;

    [HttpGet ("listar")]
    public ActionResult<List<Despesa>> ListarDespesas()
    {
        return Ok(listaDeDespesas);
    } 

    [HttpPost("cadastrar")]
    public ActionResult<Despesa> CadastrarDespesa([FromBody] Despesa novaDespesa)
    {
        if(listaDeDespesas.Any(d => d.Descricao.Equals(novaDespesa.Descricao)))
        {
            return BadRequest ("Já existe uma despesa com a mesma descrição.");
        }
        
        novaDespesa.Id = IdAtual;
        IdAtual++;

        listaDeDespesas.Add(novaDespesa);
        return Ok(novaDespesa);
    }

    [HttpPut("alterar/{id}")]
    public ActionResult<Despesa> AlterarDespesa(int id, [FromBody] Despesa despesaParaAlterar)
    {
        Despesa? despesaAlterada = listaDeDespesas.FirstOrDefault(d => d.Id == id);

        if(despesaParaAlterar is null)
        {
            return BadRequest("Id da despesa não encontrado.");
        }

        despesaParaAlterar.Descricao = despesaAlterada.Descricao;
        despesaParaAlterar.Valor = despesaAlterada.Valor;
        despesaParaAlterar.StatusPago = despesaAlterada.StatusPago;

        return despesaAlterada;
    }

    [HttpDelete ("deletar/{id}")]
    public ActionResult DeletarDespesa(int id)
    {
        Despesa? despesaParaDeletar = listaDeDespesas.FirstOrDefault(d => d.Id == id);

        if(despesaParaDeletar is null)
        {
            return BadRequest("Id da despesa não encontrado.");
        }

        listaDeDespesas.Remove(despesaParaDeletar);

        return NoContent();
    }
}

public class Despesa
{
    public int Id {get; set;}
    public string? Descricao {get; set;}
    public double Valor {get; set;}
    public bool StatusPago {get; set;}
}