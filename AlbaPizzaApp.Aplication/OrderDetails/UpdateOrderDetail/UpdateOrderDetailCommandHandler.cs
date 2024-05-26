using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.OrderDetails;
using AlbaPizzaApp.Domain.Orders;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Application.OrderDetails.UpdateOrderDetail;
internal sealed class UpdateOrderDetailCommandHandler : ICommandHandler<UpdateOrderDetailCommand>
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderDetailCommandHandler(
        IOrderDetailRepository orderDetailRepository,
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork)
    {
        _orderDetailRepository = orderDetailRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id, cancellationToken);

        if (orderDetail is null)
        {
            return Result.Failure(OrderDetailErrors.NotFound);
        }

        var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);

        if (order is null)
        {
            return Result.Failure(OrderErrors.NotFound);
        }

        if (order.Status != OrderStatus.Pending)
        {
            return Result.Failure(OrderDetailErrors.NotPendingToUpdate);
        }

        if (!Enum.TryParse<ProductTaxType>(request.TaxType, true, out var taxType))
        {
            return Result.Failure<Guid>(ProductErrors.NotValidTaxType);
        }

        orderDetail.Update(request.Quantity, request.UnitPrice, taxType);

        _orderDetailRepository.Update(orderDetail);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}


