using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    string connectionString = "Server=localhost;Port=5432;Database=Exam3;User Id=postgres;Password=1983;";
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
