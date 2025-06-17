using System.Text;
using SistemaHotel.Models;

Console.OutputEncoding=Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
Pessoa p1 = new Pessoa("Jean Claude","Van Dame");
Pessoa p2 = new Pessoa("Jackie","Chan");

hospedes.Add(p1);
hospedes.Add(p2);

Suite suite = new Suite("Premium",3,30);
Reserva reserva = new Reserva(10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

void formatter()
{
    for (int index = 0; index < 25; index++)
    {
        Console.Write("==");
    }
    
}

void titulo(string nome)
{
    Console.Write("\n======           " + nome + "          ======\n");
}

void coracaoWannabe()
{ 
    Console.WriteLine(" ");
    Console.Write(" ");
    for (int linhas = 6; linhas >= 3; linhas--)
    { 
        Console.Write("&&");
    }
    Console.WriteLine(" ");
    for (int linhas = 6; linhas > 0; linhas--)
    {
        for (int caracteres = linhas; caracteres > 0; caracteres--)
        {
            Console.Write("&&");
            
        }
        Console.WriteLine(" ");
    }
    
}

formatter();
titulo("HOTEL DE ACAPULCO");
formatter();
Console.WriteLine($"\n Hóspedes: {reserva.ObterQuantidadeHospedes()}");

foreach (Pessoa item in hospedes)
{
    Console.WriteLine($"-------------- {item.NomeCompleto} --------------");
}
Console.WriteLine($"Tipo de suite: {suite.TipoSuite}");
Console.WriteLine($"Valor da Diária: {reserva.ValorDiaria()}");
coracaoWannabe();


