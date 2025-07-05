using ApiCrud.Api.Estudantes;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Estudante> Estudantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = banco.sqlite");
        optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information); 
        base.OnConfiguring(optionsBuilder);
    }
}
