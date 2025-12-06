/*Pendente:
    - Parte 4.2: Regra para o usuário não sair do limite do grid, se tentar sair avisar com "Parede!" e não diminuir a bateria;
    - Parte 5 (toda): A parte difícl;
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

//Saída no console temporária. Apenas para acompanhar o raciocínio
Console.WriteLine("Jogador X: " + jogadorX);
Console.WriteLine("Jogador Y: " + jogadorY);
Console.WriteLine("Saída X: " + saidaX);
Console.WriteLine("Saída Y: " + saidaY);
Console.WriteLine("Monstro X: " + monstroX);
Console.WriteLine("Monstro Y: " + monstroY);
Console.WriteLine("Bateria: " + bateria);

//Laço que determina o fim do jogo
do
{

    Console.WriteLine("Informe um comando: W(Cima), A(Esquerda), S(Baixo), D (Direita)");
    //Laço para os casos em que o usuário informa um comando inválido
    do
    {
        comando = Console.ReadKey();

        switch (comando.Key)
        {
            case ConsoleKey.W:
                if (jogadorX == minimoGrid)
                {
                    Console.WriteLine("Parede!");
                }
                else
                {
                    comandoValido = true;
                    jogadorX--;
                    bateria--;
                    Console.WriteLine("Você clicou para Cima");
                }
                break;

            case ConsoleKey.A:
                if (jogadorY == minimoGrid)
                {
                    Console.WriteLine("Parede!");
                }
                else
                {
                    comandoValido = true;
                    jogadorY--;
                    bateria--;
                    Console.WriteLine("Você clicou para Esquerda");
                }
                break;

            case ConsoleKey.S:
                if (jogadorX == maximoGrid - 1)
                {
                    Console.WriteLine("Parede!");
                }
                else
                {
                    comandoValido = true;
                    jogadorX++;
                    bateria--;
                    Console.WriteLine("Você clicou para Baixo");
                }
                break;

            case ConsoleKey.D:
                if (jogadorY == maximoGrid - 1)
                {
                    Console.WriteLine("Parede!");
                }
                else
                {
                    comandoValido = true;
                    jogadorY++;
                    bateria--;
                    Console.WriteLine("Você clicou para Direita");
                }
                break;

            default:
                comandoValido = false;
                Console.WriteLine("Informe um comando válido:");
                break;
        }
    } while (comandoValido == false);

    //Saída no console temporária. Apenas para acompanhar o raciocínio
    Console.WriteLine("Jogador X: " + jogadorX);
    Console.WriteLine("Jogador Y: " + jogadorY);
    Console.WriteLine("Saída X: " + saidaX);
    Console.WriteLine("Saída Y: " + saidaY);
    Console.WriteLine("Monstro X: " + monstroX);
    Console.WriteLine("Monstro Y: " + monstroY);
    Console.WriteLine("Bateria: " + bateria);

    if (jogadorX == saidaX && jogadorY == saidaY)
    {
        jogadorVenceu = true;
        Console.WriteLine("Você encontrou a luz!");
    }
    else if (jogadorX == monstroX && jogadorY == monstroY)
    {
        monstroVenceu = true;
        Console.WriteLine("O monstro te pegou!");
    }
    else if (bateria == 0)
    {
        bateriaAcabou = true;
        Console.WriteLine("Sua lanterna apagou. Escuridão eterna.");
    }

} while (jogadorVenceu == false && monstroVenceu == false && bateriaAcabou == false);

