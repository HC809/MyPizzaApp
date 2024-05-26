namespace AlbaPizzaApp.Domain.Customers;
public interface ICustomerRepository 
{
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Customer product);
    void Update(Customer product);
    void Remove(Customer product);
    Task<bool> ExistCustomerByEmail(string email, CancellationToken cancellationToken = default);
    Task<bool> ExistCustomerByPhone(string phone, CancellationToken cancellationToken = default);
    Task<bool> ExistCustomerByEmailExcludingId(string email, Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistCustomerByPhoneExcludingId(string phone, Guid id, CancellationToken cancellationToken = default);
}