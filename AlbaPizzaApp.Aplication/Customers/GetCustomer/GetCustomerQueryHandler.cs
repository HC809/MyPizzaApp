using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Customers;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Customers.GetCustomer;
internal sealed class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, CustomerResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetCustomerByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<CustomerResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                Name, 
                Email, 
                Phone 
            FROM Customers
            WHERE Id = @CustomerId;
            """;

        var customer = await connection.QuerySingleOrDefaultAsync<CustomerResponse>(sqlQuery, new { request.CustomerId });

        if (customer == null)
        {
            return Result.Failure<CustomerResponse>(CustomerErrors.NotFound);
        }

        return Result.Success(customer);
    }
}

