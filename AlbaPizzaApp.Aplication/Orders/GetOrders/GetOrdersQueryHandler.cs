using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Orders.GetOrders;
internal sealed class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IEnumerable<OrderResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetOrdersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<OrderResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                CustomerId, 
                OrderDate, 
                Subtotal, 
                TaxAmount, 
                TotalAmount, 
                Status, 
                ConfirmDate, 
                CancelDate 
            FROM Orders;
            """;

        var orders = await connection.QueryAsync<OrderResponse>(sqlQuery);

        return Result.Success(orders);
    }
}

