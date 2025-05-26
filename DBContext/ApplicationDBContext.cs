using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductCartTest.DBContext;

public class ApplicationDBContext
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public ApplicationDBContext(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

}
