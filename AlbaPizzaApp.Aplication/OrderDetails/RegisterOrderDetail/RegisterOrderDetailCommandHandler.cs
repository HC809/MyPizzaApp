using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.OrderDetails;
using AlbaPizzaApp.Domain.Orders;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Application.OrderDetails.RegisterOrderDetail;
internal sealed class RegisterOrderDetailCommandHandler : ICommandHandler<RegisterOrderDetailCommand, Guid>
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterOrderDetailCommandHandler(
        IOrderDetailRepository orderDetailRepository,
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork)
    {
        _orderDetailRepository = orderDetailRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);

        if (order is null)
        {
            return Result.Failure<Guid>(OrderErrors.NotFound);
        }

        if (order.Status != OrderStatus.Pending)
        {
            return Result.Failure<Guid>(OrderDetailErrors.NotPendingToRegister);
        }

        if (!Enum.TryParse<ProductTaxType>(request.TaxType, true, out var taxType))
        {
            return Result.Failure<Guid>(ProductErrors.NotValidTaxType);
        }

        var orderDetail = OrderDetail.Create(request.OrderId, request.ProductId, taxType, request.Quantity, request.UnitPrice);

        _orderDetailRepository.Add(orderDetail);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(orderDetail.Id);
    }
}

