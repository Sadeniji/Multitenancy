namespace Multitenancy.Services
{
    public interface IProductService
    {
        Task<Product?> GetProductAsync(int productId, CancellationToken cancellationToken);
        Task<Product?> CreateProductAsync(Product product);
        Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken);
    }
}
