using AlbaPizzaApp.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace AlbaPizzaApp.Infraestructure.Repositories;
internal sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<bool> ExistCustomerByEmail(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Customer>().AnyAsync(c => c.Email == email, cancellationToken);
    }

    public async Task<bool> ExistCustomerByPhone(string phone, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Customer>().AnyAsync(c => c.Phone == phone, cancellationToken);
    }

    public async Task<bool> ExistCustomerByEmailExcludingId(string email, Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Customer>().AnyAsync(c => c.Email == email && c.Id != id, cancellationToken);
    }

    public async Task<bool> ExistCustomerByPhoneExcludingId(string phone, Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Customer>().AnyAsync(c => c.Phone == phone && c.Id != id, cancellationToken);
    }
}
