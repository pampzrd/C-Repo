
using ApiCrudP.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudP.Livros;

public static class LivrosRotas
{
    public static void AddRotas(this WebApplication app)
    {
        var rotasLivros = app.MapGroup("Livros");
        rotasLivros.MapGet("", async (AppDbContext context, CancellationToken ct) =>
        {
            var livros = await context
                .Livros
                .Where(livros => livros.Disponivel)
                .Select(livro => new LivroDTO(livro.Id, livro.Titulo,livro.Autor))
                .ToListAsync(ct);
            return livros;
        });
        rotasLivros.MapPost("", async (AddLivro request, AppDbContext context, CancellationToken ct) =>
        {
            var jaExiste = await context.Livros
                .AnyAsync(livro => livro.Titulo == request.titulo, ct);
            if(jaExiste)
                return Results.Conflict("Já Existe!");
            var novoLivro = new Livro(request.titulo, request.autor);
            await context.Livros.AddAsync(novoLivro, ct);
            await context.SaveChangesAsync(ct);
            var retorno = new LivroDTO(novoLivro.Id,novoLivro.Titulo,novoLivro.Autor);
            return Results.Ok(retorno);
        });
        rotasLivros.MapPut("{id:guid}",
            async (Guid id, UpdateLivro request, AppDbContext context, CancellationToken ct) =>
            {
                var livros = await context.Livros
                    .SingleOrDefaultAsync(livros => livros.Id == id, ct);
                if(livros==null)
                return Results.NotFound();
                livros.UpdateTituloAutor(request.titulo,request.autor);
                await context.SaveChangesAsync(ct);
                return Results.Ok(new LivroDTO(livros.Id, livros.Titulo, livros.Autor));
            });
        
        
        rotasLivros.MapDelete("{id}", async (Guid id, AppDbContext context,CancellationToken ct) =>
        {
            var livro = await context.Livros.SingleOrDefaultAsync(livro => livro.Id == id, ct);
            if (livro == null)
                return Results.NotFound();
            livro.Desativar();
            await context.SaveChangesAsync(ct);
            return Results.Ok();
        });
    }
    
}