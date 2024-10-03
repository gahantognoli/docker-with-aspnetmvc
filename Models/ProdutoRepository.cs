using mvc1.Models;

namespace mvc1.Models
{
    public class ProdutoRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public ProdutoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Produto> Produtos => _dbContext.Produtos;
    }
}