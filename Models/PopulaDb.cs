using Microsoft.EntityFrameworkCore;

namespace mvc1.Models
{
    public static class PopulaDb
    {
        public static void IncluiDadosDB(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                IncluiDadosDB(dbContext);
            }
        }

        public static void IncluiDadosDB(AppDbContext dbContext)
        {
            dbContext.Database.Migrate();
            if (!dbContext.Produtos.Any())
            {
                var produtos = Enumerable.Range(1, 100)
                    .Select(i => new Produto($"produto_{i}", "teste", new Random().Next()));
                dbContext.Produtos.AddRange(produtos);
                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Dados já existem...");
            }
        }
    }
}