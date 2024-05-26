using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;
using AlbaPizzaApp.Infraestructure.Abstractions;
using Dapper;

namespace AlbaPizzaApp.Application.Addresses.GetAddress;
internal sealed class GetAddressByIdQueryHandler : IQueryHandler<GetAddressByIdQuery, AddressResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAddressByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<AddressResponse>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
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
            WHERE Id = @AddressId;
            """;

        var address = await connection.QuerySingleOrDefaultAsync<AddressResponse>(sqlQuery, new { request.AddressId });

        if (address == null)
        {
            return Result.Failure<AddressResponse>(AddressErrors.NotFound);
        }

        return Result.Success(address);
    }
}

