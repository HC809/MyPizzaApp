using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Addresses.GetAddressByCustomer;
internal sealed class GetAddressesByCustomerIdQueryHandler : IQueryHandler<GetAddressesByCustomerIdQuery, IEnumerable<AddressResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAddressesByCustomerIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<AddressResponse>>> Handle(GetAddressesByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                CustomerId,
                Street, 
                City, 
                State, 
                ZipCode, 
                Country
            FROM Addresses
            WHERE CustomerId = @CustomerId;
            """;

        var addresses = await connection.QueryAsync<AddressResponse>(sqlQuery, new { request.CustomerId });

        return Result.Success(addresses);
    }
}

