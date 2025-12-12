/*Pendente:
    - Alterar IA do Monstro para Lista + Random;
    - Alterar versão do .net;
    - Migrar prints de tela para modo debug.
*/

int minimoGrid = 0;
int maximoGrid = 10;
int jogadorX = 0;
int jogadorY = 0;
int saidaX = 0;
int saidaY = 0;
int monstroX = 0;
int monstroY = 0;
int bateria = 20;
bool jogadorVenceu = false;
bool monstroVenceu = false;
bool bateriaAcabou = false;
bool movimentoExecutado = false;
Random sorteador = new Random();

do
{
    jogadorX = sorteador.Next(minimoGrid, maximoGrid);
    jogadorY = sorteador.Next(minimoGrid, maximoGrid);
} while ((jogadorX == monstroX && jogadorY == monstroY) || (jogadorX == saidaX && jogadorY == saidaY));

do
{
    saidaX = sorteador.Next(minimoGrid, maximoGrid);
    saidaY = sorteador.Next(minimoGrid, maximoGrid);
} while ((saidaX == monstroX && saidaY == monstroY) || (saidaX == jogadorX && saidaY == jogadorY));

do
{
    monstroX = sorteador.Next(minimoGrid, maximoGrid);
    monstroY = sorteador.Next(minimoGrid, maximoGrid);
} while ((monstroX == jogadorX && monstroY == jogadorY) || (monstroX == saidaX && monstroY == saidaY));

//Laço que determina o fim do jogo
do
{
    Console.WriteLine("\nInforme um comando: W(Cima), A(Esquerda), S(Baixo), D (Direita)");

    do
    {
        movimentoExecutado = false;
        ConsoleKey comando = Console.ReadKey(true).Key;
        movimentoExecutado = moverJogador(comando, minimoGrid, maximoGrid, ref jogadorX, ref jogadorY, ref bateria);

    } while (movimentoExecutado == false);

    moverMonstro(sorteador, ref monstroX, ref monstroY, minimoGrid, maximoGrid);

    int distanciaSaida = Math.Abs(jogadorX - saidaX) + Math.Abs(jogadorY - saidaY);
    int distanciaMonstro = Math.Abs(jogadorX - monstroX) + Math.Abs(jogadorY - monstroY);

    /*
    //Apenas para me localizar. Remover após implementação completa.
    Console.WriteLine("\n-----------------------------");
    Console.WriteLine("Análise após o seu movimento:");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Jogador X: " + jogadorX);
    Console.WriteLine("Jogador Y: " + jogadorY);
    Console.WriteLine("Saída X: " + saidaX);
    Console.WriteLine("Saída Y: " + saidaY);
    Console.WriteLine("Monstro X: " + monstroX);
    Console.WriteLine("Monstro Y: " + monstroY);
    Console.WriteLine("Bateria: " + bateria);
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Distância Saída: " + distanciaSaida);
    Console.WriteLine("Distância Monstro: " + distanciaMonstro);
    Console.WriteLine("-----------------------------");
    */

    //Condições para o Sistema Sonar
    if (distanciaSaida <= 2)
    {
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("O sensor apita rápido! A saída está muito perto!");
        Console.WriteLine("-----------------------------");
    }
    else if (distanciaSaida <= 5)
    {
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("O sensor apita devagar.");
        Console.WriteLine("-----------------------------");
    }

    if (distanciaMonstro == 1)
    {
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("Cheiro podre muito forte!");
        Console.WriteLine("-----------------------------");
    }

    //Condições para vitória ou derrota
    if (jogadorX == saidaX && jogadorY == saidaY)
    {
        jogadorVenceu = true;
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("Você encontrou a luz!");
        Console.WriteLine("-----------------------------");
    }
    else if (jogadorX == monstroX && jogadorY == monstroY)
    {
        monstroVenceu = true;
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("O monstro te pegou!");
        Console.WriteLine("-----------------------------");
    }
    else if (bateria == 0)
    {
        bateriaAcabou = true;
        Console.WriteLine("\n-----------------------------");
        Console.WriteLine("Sua lanterna apagou. Escuridão eterna.");
        Console.WriteLine("-----------------------------");
    }

} while (jogadorVenceu == false && monstroVenceu == false && bateriaAcabou == false);

//Métodos de movimentação do jogador e monstro

static bool moverJogador(ConsoleKey tecla, int minimoGrid, int maximoGrid, ref int jogadorX, ref int jogadorY, ref int bateria)
{
    int movimentoX = 0;
    int movimentoY = 0;

    switch (tecla)
    {
        case ConsoleKey.W:
            movimentoX = -1;
            break;
        case ConsoleKey.S:
            movimentoX = 1;
            break;
        case ConsoleKey.A:
            movimentoY = -1;
            break;
        case ConsoleKey.D:
            movimentoY = 1;
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Informe um comando válido.");
            Console.WriteLine("-----------------------------");
            return false;
    }

    int novoJogadorX = jogadorX + movimentoX;
    int novoJogadorY = jogadorY + movimentoY;

    bool saiuDoGrid = novoJogadorX < minimoGrid || novoJogadorX >= maximoGrid
    || novoJogadorY < minimoGrid || novoJogadorY >= maximoGrid;

    if (saiuDoGrid)
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Parede!");
        Console.WriteLine("-----------------------------");
        return false;
    }

    jogadorX = novoJogadorX;
    jogadorY = novoJogadorY;
    bateria = Math.Max(0, bateria - 1);
    return true;
}

static bool moverMonstro(Random sorteador, ref int monstroX, ref int monstroY, int minimoGrid, int maximoGrid)
{
    int movimentoX = 0;
    int movimentoY = 0;

    int numeroAleatorio = sorteador.Next(0, 2);

    if (numeroAleatorio == 0)
    {
        movimentoX = -1;
    }
    else if (numeroAleatorio == 1)
    {
        movimentoX = 1;
    }

    numeroAleatorio = sorteador.Next(2, 4);

    if (numeroAleatorio == 2)
    {
        movimentoY = -1;
    }
    else if (numeroAleatorio == 3)
    {
        movimentoY = 1;
    }

    int novoMonstroX = monstroX + movimentoX;
    int novoMonstroY = monstroY + movimentoY;

    bool saiuDoGrid = novoMonstroX < minimoGrid || novoMonstroX >= maximoGrid
    || novoMonstroY < minimoGrid || novoMonstroY >= maximoGrid;

    if (saiuDoGrid)
    {
        return false;
    }

    monstroX = novoMonstroX;
    monstroY = novoMonstroY;

    return true;
}
