using AlbaPizzaApp.Domain.OrderDetails;

namespace AlbaPizzaApp.Infraestructure.Repositories;
internal class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
