using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Addresses.GetAddresses;
internal sealed class GetAddressesQueryHandler : IQueryHandler<GetAddressesQuery, IEnumerable<AddressResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAddressesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<AddressResponse>>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
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
            FROM Addresses;
            """;

        var addresses = await connection.QueryAsync<AddressResponse>(sqlQuery);

        return Result.Success(addresses);
    }
}

