using Microsoft.EntityFrameworkCore;
using Multitenancy.Data;

namespace Multitenancy.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductAsync(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(productId, cancellationToken);
        }

        public async Task<Product?> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
