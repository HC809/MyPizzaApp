using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Orders;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Orders.GetOrder;
internal sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetOrderByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                CustomerId, 
                AddressId,
                OrderDate, 
                Subtotal, 
                TaxAmount, 
                TotalAmount, 
                Status, 
                ConfirmDate, 
                CancelDate 
            FROM Orders
            WHERE Id = @OrderId;
            """;

        var order = await connection.QuerySingleOrDefaultAsync<OrderResponse>(sqlQuery, new { request.OrderId });

        if (order == null)
        {
            return Result.Failure<OrderResponse>(OrderErrors.NotFound);
        }

        return Result.Success(order);
    }
}

