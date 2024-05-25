using Dapper;
using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Infraestructure.Abstractions;
using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Application.Products.GetProducts;
internal sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetProductsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sqlQuery = """
            SELECT 
                Id, 
                Description, 
                Price, 
                TaxType 
            FROM Products;
            """;

        var products = await connection.QueryAsync<ProductResponse>(sqlQuery);

        return Result.Success(products);
    }
}
