/*Pendente:
    - Parte 6: Desafio Extra;
    - Revisar código.
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
bool comandoValido = false;
ConsoleKeyInfo comando;
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

    //Laço para os casos em que o usuário informa um comando inválido
    do
    {
        comando = Console.ReadKey();

        switch (comando.Key)
        {
            case ConsoleKey.W:
                if (jogadorX == minimoGrid)
                {
                    Console.WriteLine("\n-----------------------------");
                    Console.WriteLine("\nParede!");
                    Console.WriteLine("-----------------------------");
                }
                else
                {
                    comandoValido = true;
                    jogadorX--;
                    bateria--;
                }
                break;

            case ConsoleKey.A:
                if (jogadorY == minimoGrid)
                {
                    Console.WriteLine("\n-----------------------------");
                    Console.WriteLine("\nParede!");
                    Console.WriteLine("-----------------------------");
                }
                else
                {
                    comandoValido = true;
                    jogadorY--;
                    bateria--;
                }
                break;

            case ConsoleKey.S:
                if (jogadorX == maximoGrid - 1)
                {
                    Console.WriteLine("\n-----------------------------");
                    Console.WriteLine("\nParede!");
                    Console.WriteLine("-----------------------------");
                }
                else
                {
                    comandoValido = true;
                    jogadorX++;
                    bateria--;
                }
                break;

            case ConsoleKey.D:
                if (jogadorY == maximoGrid - 1)
                {
                    Console.WriteLine("\n-----------------------------");
                    Console.WriteLine("\nParede!");
                    Console.WriteLine("-----------------------------");
                }
                else
                {
                    comandoValido = true;
                    jogadorY++;
                    bateria--;
                }
                break;

            default:
                comandoValido = false;
                Console.WriteLine("\n-----------------------------");
                Console.WriteLine("Informe um comando válido:");
                break;
        }
    } while (comandoValido == false);


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

