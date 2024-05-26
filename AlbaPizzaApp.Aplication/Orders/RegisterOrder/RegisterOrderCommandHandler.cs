using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;
using AlbaPizzaApp.Domain.OrderDetails;
using AlbaPizzaApp.Domain.Orders;

namespace AlbaPizzaApp.Application.Orders.RegisterOrder;
internal sealed class RegisterOrderCommandHandler : ICommandHandler<RegisterOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IAddressRepository addressRepository)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
    }

    public async Task<Result<Guid>> Handle(RegisterOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(request.CustomerId, request.AddressId, request.OrderDate);

        var address = await _addressRepository.GetByIdAsync(request.AddressId, cancellationToken);

        if (address is null)
        {
            return Result.Failure<Guid>(AddressErrors.NotFound);
        }

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

