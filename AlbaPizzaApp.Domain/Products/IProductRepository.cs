namespace AlbaPizza.Domain.Products;
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    Task<bool> ExistProductByDescription(string description, CancellationToken cancellationToken = default);
    Task<bool> ExistProductByDescriptionExcludingId(string description, Guid id, CancellationToken cancellationToken = default);
}
