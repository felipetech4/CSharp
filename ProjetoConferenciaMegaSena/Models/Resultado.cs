namespace ProjetoConferenciaMegaSena.Models;

public class Resultado
{
    public int JogoId {get; set;}
    public int Acertos {get;set;}
    public List<int> NumerosAcertados {get; set;} = new();
    public string Premio {get;set;} = "Sem premio";
}