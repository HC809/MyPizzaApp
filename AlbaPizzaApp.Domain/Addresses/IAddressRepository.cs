namespace AlbaPizzaApp.Domain.Addresses;
public interface IAddressRepository
{
    Task<Address?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Address product);
    void Update(Address product);
    void Remove(Address product);
}
