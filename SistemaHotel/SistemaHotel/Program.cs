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

void coracao()
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
        Console.Write(" ");
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
coracao();

