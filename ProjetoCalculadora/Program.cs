//Pendente receber dados de entrada sem precisar do Enter

int n1;
int n2;
string operacao;
double resultado = 0.0;

Console.WriteLine("7 | 8 | 9");
Console.WriteLine("4 | 5 | 6");
Console.WriteLine("1 | 2 | 3");
Console.WriteLine("0 | + | -");
Console.WriteLine("* | / | =");
Console.WriteLine("Cálculo: ");
n1 = Convert.ToInt32(Console.ReadLine());
operacao = Console.ReadLine();
n2 = Convert.ToInt32(Console.ReadLine());

switch (operacao)
{
    case "+":
    resultado = adicao(n1, n2);
    break;

    case "-":
    resultado = subtracao(n1, n2);
    break;

    case "*":
    resultado = multiplicacao(n1, n2);
    break;

    case "/":
    resultado = divisao(n1, n2);
    break;

    default:
    Console.WriteLine("Operação inválida.");
    break;
}

Console.WriteLine("Resultado: " + resultado);

static float adicao (float n1, float n2)
{
    return n1 + n2;
}

static float subtracao (float n1, float n2)
{
    return n1 - n2;
}

static float multiplicacao (float n1, float n2)
{
    return n1 * n2;
}

static float divisao (float n1, float n2)
{
    return n1 / n2;
}