using System.Data;

namespace AlbaPizzaApp.Infraestructure.Abstractions;
public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
