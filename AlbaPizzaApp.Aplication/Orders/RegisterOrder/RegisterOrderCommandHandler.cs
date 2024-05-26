using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.OrderDetails;
using AlbaPizzaApp.Domain.Orders;

namespace AlbaPizzaApp.Application.Orders.RegisterOrder;
internal sealed class RegisterOrderCommandHandler : ICommandHandler<RegisterOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(request.CustomerId, request.OrderDate);

        foreach (var detail in request.OrderDetails)
        {
            var orderDetail = OrderDetail.Create(order.Id, detail.ProductId, detail.TaxType, detail.Quantity, detail.UnitPrice);
            order.AddOrderDetail(orderDetail);
        }

        _orderRepository.Add(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(order.Id);
    }
}

