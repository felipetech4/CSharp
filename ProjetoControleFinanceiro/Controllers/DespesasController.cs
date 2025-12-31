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
        if(listaDeDespesas.Where(d => d.Descricao.Equals(novaDespesa.Descricao)).Any())
        {
            return BadRequest ("Já existe uma despesa com a mesma descrição.");
        }
        
        novaDespesa.Id = IdAtual;
        IdAtual++;

        listaDeDespesas.Add(novaDespesa);
        return Ok(novaDespesa);
    }
}

public class Despesa
{
    public int Id {get; set;}
    public string? Descricao {get; set;}
    public double Valor {get; set;}
    public bool StatusPago {get; set;}
}