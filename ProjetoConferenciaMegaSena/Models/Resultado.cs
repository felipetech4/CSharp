public class Resultado
{
    public int JogoId {get; set;}
    public int Acertos {get;set;}
    public List<int> NumerosAcertados {get; set;} = new();
}