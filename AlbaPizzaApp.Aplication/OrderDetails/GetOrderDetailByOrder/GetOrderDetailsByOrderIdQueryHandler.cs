using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.OrderDetails.GetOrderDetailByOrder;
internal sealed class GetOrderDetailsByOrderIdQueryHandler : IQueryHandler<GetOrderDetailsByOrderIdQuery, IEnumerable<OrderDetailResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetOrderDetailsByOrderIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<OrderDetailResponse>>> Handle(GetOrderDetailsByOrderIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                OrderId, 
                ProductId, 
                Quantity, 
                UnitPrice, 
                TaxType, 
                PriceWithoutTax, 
                TaxAmount, 
                PriceWithTax 
            FROM OrderDetails
            WHERE OrderId = @OrderId;
            """;

        var orderDetails = await connection.QueryAsync<OrderDetailResponse>(sqlQuery, new { request.OrderId });

        return Result.Success(orderDetails);
    }
}

