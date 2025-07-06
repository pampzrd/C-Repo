using System.ComponentModel.DataAnnotations;

namespace ApiCrudP.Livros;

public class Livro
{
    [Key]
    public Guid Id { get; init; }
    [Required(ErrorMessage = "Preencha o Título!")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Preencha o Autor!")]
    public string Autor { get; set; }
    public DateTime DataInclusao { get; set; }
    public Boolean Disponivel { get; set; }

    public Livro(string titulo,string autor)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Autor = autor;
        Disponivel = true;
        DataInclusao=DateTime.Now;

    }

    public void UpdateTituloAutor(string titulo,string autor)
    {
        Titulo = titulo;
        Autor = autor;
    }
    
    public void Desativar()
    {
        Disponivel = false;
    }
    
    
    
}

