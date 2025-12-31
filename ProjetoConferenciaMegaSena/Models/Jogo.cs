namespace ProjetoConferenciaMegaSena.Models;

public class Jogo
{
    public int JogoId {get; set;}
    public List<int> Numeros {get; set;} = new();
}