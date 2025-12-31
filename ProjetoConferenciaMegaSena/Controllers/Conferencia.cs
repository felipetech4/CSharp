using Microsoft.AspNetCore.Mvc;
using ProjetoConferenciaMegaSena.Models;

namespace ProjetoConferenciaMegaSena.Controllers;

[ApiController]
[Route ("api/[controller]")]

public class ConferenciaController : ControllerBase
{
    [HttpPost]
    public ActionResult Conferir([FromBody] Request bodyRequest)
    {
        var resultados = new List<Resultado>();

        foreach (var jogo in bodyRequest.Jogos)
        {
            if(jogo.Numeros.Count != 6)
            {
                return BadRequest($"O jogo {jogo.JogoId} não possui 6 números.");
            }

            var acertados = jogo.Numeros
            .Intersect(bodyRequest.NumerosSorteados)
            .OrderBy(n => n)
            .ToList();

            var premio = acertados.Count switch
            {
                6 => "Você é o novo Milionário!",
                5 => "Você acertou o prêmio da Quina!",
                4 => "Você acertou o prêmio da Quadra!",
                _ => "Não foi dessa vez... =("
            };

            resultados.Add(new Resultado
            {
                JogoId = jogo.JogoId,
                Acertos = acertados.Count,
                NumerosAcertados = acertados,
                Premio = premio
            });
        }

        return Ok(resultados);
    }
}