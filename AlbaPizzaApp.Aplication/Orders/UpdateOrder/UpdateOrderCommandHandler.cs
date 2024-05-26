using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;
using AlbaPizzaApp.Domain.OrderDetails;
using AlbaPizzaApp.Domain.Orders;

namespace AlbaPizzaApp.Application.Orders.UpdateOrder;
internal sealed class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IAddressRepository addressRepository)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _addressRepository = addressRepository;
    }

    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return Result.Failure(OrderErrors.NotFound);
        }

        var address = await _addressRepository.GetByIdAsync(request.AddressId, cancellationToken);

        if (address is null)
        {
            return Result.Failure(AddressErrors.NotFound);
        }

        var orderDetails = request.OrderDetails.Select(d => OrderDetail.Create(order.Id, d.ProductId, d.TaxType, d.Quantity, d.UnitPrice)).ToList();
        var result = order.Update(request.OrderDate, request.AddressId, orderDetails);

        if (result.IsFailure)
        {
            return result;
        }

        _orderRepository.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
