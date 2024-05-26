using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.OrderDetails;
using AlbaPizzaApp.Domain.Orders;

namespace AlbaPizzaApp.Application.OrderDetails.RemoveOrderDetail;
internal sealed class RemoveOrderDetailCommandHandler : ICommandHandler<RemoveOrderDetailCommand>
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveOrderDetailCommandHandler(
        IOrderDetailRepository orderDetailRepository,
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork)
    {
        _orderDetailRepository = orderDetailRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id, cancellationToken);

        if (orderDetail is null)
        {
            return Result.Failure(OrderErrors.NotFound);
        }

        var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);

        if (order is null)
        {
            return Result.Failure(OrderErrors.NotFound);
        }

        if (order.Status != OrderStatus.Pending)
        {
            return Result.Failure(OrderDetailErrors.NotPendingToDelete);
        }

        _orderDetailRepository.Remove(orderDetail);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

