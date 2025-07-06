using ApiCrudP.Livros;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudP.Data;

public class AppDbContext:DbContext
{
    public DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = bancoLivros.sqlite");  
        optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information);
        base.OnConfiguring(optionsBuilder);
    }
}