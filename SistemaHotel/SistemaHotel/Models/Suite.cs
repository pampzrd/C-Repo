namespace SistemaHotel.Models;

public class Suite
{
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    public Suite()
    {
        
    }
    public Suite(string tipoSuite,int capacidade,decimal valorDiaria)
    {
        Capacidade = capacidade;
        TipoSuite = tipoSuite;
        ValorDiaria = valorDiaria;
    }

}