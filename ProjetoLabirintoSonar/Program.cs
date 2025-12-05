int minimoGrid = 0;
int maximoGrid = 9;
int jogadorX;
int jogadorY;
int saidaX;
int saidaY;
int monstroX;
int monstroY;
string comando;
bool comandoValido;

Random sorteador = new Random();

jogadorX = sorteador.Next(minimoGrid, maximoGrid);
jogadorY = sorteador.Next(minimoGrid, maximoGrid);
saidaX = sorteador.Next(minimoGrid, maximoGrid);
saidaY = sorteador.Next(minimoGrid, maximoGrid);
monstroX = sorteador.Next(minimoGrid, maximoGrid);
monstroY = sorteador.Next(minimoGrid, maximoGrid);

Console.WriteLine("Jogador X: " + jogadorX);
Console.WriteLine("Jogador Y: " + jogadorY);

Console.WriteLine("Informe um comando: W(Cima), A(Esquerda), S(Baixo), D (Direita)");

do
{
    comando = Console.ReadLine();


    switch (comando)
    {
        case "W":
            comandoValido = true;
            jogadorX--;
            Console.WriteLine("Você clicou para Cima");
            break;

        case "A":
            comandoValido = true;
            jogadorY--;
            Console.WriteLine("Você clicou para Esquerda");
            break;

        case "S":
            comandoValido = true;
            jogadorX++;
            Console.WriteLine("Você clicou para Baixo");
            break;

        case "D":
            comandoValido = true;
            jogadorY++;
            Console.WriteLine("Você clicou para Direita");
            break;

        default:
            comandoValido = false;
            Console.WriteLine("Informe um comando válido:");
            break;
    }
} while (comandoValido == false);

Console.WriteLine("Jogador X: " + jogadorX);
Console.WriteLine("Jogador Y: " + jogadorY);