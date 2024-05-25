using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace AlbaPizzaApp.Infraestructure.Repositories;
internal abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public void Add(T entity) => _dbContext.Add(entity);

    public void Update(T entity) => _dbContext.Update(entity);

    public void Remove(T entity) => _dbContext.Remove(entity);
}
