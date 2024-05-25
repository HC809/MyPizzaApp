using AlbaPizzaApp.Domain.Products;
using AlbaPizzaApp.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace AlbaPizzaApp.Infraestructure.Repositories;
internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<bool> ExistProductByDescription(string description, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Product>()
            .AnyAsync(p => p.Description == description, cancellationToken);
    }

    public async Task<bool> ExistProductByDescriptionExcludingId(string description, Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Product>()
            .AnyAsync(p => p.Description == description && p.Id != id, cancellationToken);
    }
}
