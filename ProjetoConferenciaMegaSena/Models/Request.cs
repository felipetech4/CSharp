namespace ProjetoConferenciaMegaSena.Models;

public class Request
{
    public List<int> NumerosSorteados {get; set;} = [];
    public List<Jogo> Jogos {get; set;} = [];
}