public class Heroi
{
    public int Id { get; set; }
    public string Nome { get ; set;} = "";
    public string Classe { get ; set;} = "";
    public int Nivel { get; set;}

    public string Apresentar()
    {
        return $"Olá, sou {Nome}, um {Classe} nível {Nivel}!";
    }
}