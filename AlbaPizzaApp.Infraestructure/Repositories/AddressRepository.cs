using AlbaPizzaApp.Domain.Addresses;

namespace AlbaPizzaApp.Infraestructure.Repositories;
internal sealed class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
