using ApiCrud.Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Api.Estudantes;

public static class EstudantesRotas
{
    public static void AddRotas(this WebApplication app)
    {
        var rotasEstudantes = app.MapGroup("Estudantes");  
        
        //CRIAR
        rotasEstudantes.MapPost("", 
            async (AddEstudantesRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var jaExiste = await context.Estudantes
                .AnyAsync(estudante => estudante.Nome==request.Nome,ct);
            if (jaExiste)
                return Results.Conflict("Já existe!");
            
            var novoEstudante = new Estudante(request.Nome);
            await context.Estudantes.AddAsync(novoEstudante,ct);
            await context.SaveChangesAsync(ct);
            var estudanteRetorno = new EstudanteDTO(novoEstudante.Id, novoEstudante.Nome);
            return Results.Ok(estudanteRetorno);
        });
        
        
        //RETORNAR TODOS OS ESTUDANTES
        rotasEstudantes.MapGet("", async (AppDbContext context,CancellationToken ct) =>
        {
            var estudantes = await context
                .Estudantes
                .Where(estudante => estudante.Ativo)
                .Select(estudante=>new EstudanteDTO(estudante.Id,estudante.Nome))//No javascript utilizaria Map Serve para referenciar o DTO
                .ToListAsync(ct); 
            return estudantes;
        });
        
        //ATUALIZAR DADOS
        rotasEstudantes.MapPut("{id:guid}", async (Guid id, UpdateEstudantesRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var estudante = await context.Estudantes
                .SingleOrDefaultAsync(estudante=>estudante.Id==id,ct); 
            if(estudante==null)
                return Results.NotFound();
            estudante.AtualizarNome(request.Nome); 
            await context.SaveChangesAsync(ct);
            return Results.Ok(new EstudanteDTO(estudante.Id,estudante.Nome)); 
        });
        
        // SOFT DELETE
        rotasEstudantes.MapDelete("{id}", async (Guid id, AppDbContext context,CancellationToken ct) =>
        {
            var estudante = await context.Estudantes.SingleOrDefaultAsync(estudante => estudante.Id == id,ct); 
            if(estudante==null)
                return Results.NotFound();
            estudante.Desativar();
            await context.SaveChangesAsync(ct);
            return Results.Ok();

        });
    }

}