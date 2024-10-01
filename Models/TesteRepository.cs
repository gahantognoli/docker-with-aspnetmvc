using mvc1.Models;

namespace mvc1.Models
{
    public class TesteRepository : IRepository
    {
        private static Produto[] produtos = [
            new Produto("Caneta", "Material escolar", 10, 1),
            new Produto("Borracha", "Material escolar", 5, 1),
            new Produto("Estojo", "Material escolar", 20, 1),
        ];

        public IEnumerable<Produto> Produtos => produtos;
    }
}