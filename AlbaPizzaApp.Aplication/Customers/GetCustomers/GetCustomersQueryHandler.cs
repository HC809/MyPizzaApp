using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Customers.GetCustomers;
internal sealed class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IEnumerable<CustomerResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetCustomersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<CustomerResponse>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                Name, 
                Email, 
                Phone 
            FROM Customers;
            """;

        var customers = await connection.QueryAsync<CustomerResponse>(sqlQuery);

        return Result.Success(customers);
    }
}

