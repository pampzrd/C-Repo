namespace SistemaHotel.Models;

public class Reserva
{
    public Reserva() { }
    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }
    public List<Pessoa> Hospede { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    private int _quantidadeHospedes;
    public int ObterQuantidadeHospedes()
    {
        int quantidadePessoas = Hospede.Count;
        _quantidadeHospedes = quantidadePessoas;
        return _quantidadeHospedes;
    }
    public void CadastrarHospedes(List<Pessoa> hospede)
    {
        if(Suite.Capacidade>=_quantidadeHospedes){ 
            Hospede = hospede;
            
        }else
        { throw new InvalidOperationException($"A capacidade da suíte não suporta {_quantidadeHospedes} pessoas.");
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }
    
    public decimal ValorDiaria()
    {
        int resultado = (int)(DiasReservados* Suite.ValorDiaria);
        if (DiasReservados >= 10)
        {
            resultado -= (int)(resultado * 0.1);
        }
        return resultado;
    }
    
}