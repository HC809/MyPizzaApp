using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Orders.GetOrdersByCustomer;
internal sealed class GetOrdersByCustomerIdQueryHandler : IQueryHandler<GetOrdersByCustomerIdQuery, IEnumerable<OrderResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetOrdersByCustomerIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<OrderResponse>>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
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
            FROM Orders
            WHERE CustomerId = @CustomerId;
            """;

        var orders = await connection.QueryAsync<OrderResponse>(sqlQuery, new { request.CustomerId });

        return Result.Success(orders);
    }
}

