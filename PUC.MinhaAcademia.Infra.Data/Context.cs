using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Tasken.SRC.Infra.Data.Others;

namespace Tasken.SRC.Infra.Data
{
    public class Context : IDisposable
    {
        private SqlConnection _connection;

        public readonly IHttpContextAccessor ContextAcessor;
        private readonly IConfiguration _configuration;

        public Context(IHttpContextAccessor contextAcessor, IConfiguration configuration)
        {
            ContextAcessor = contextAcessor;
            _configuration = configuration;

            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
            SqlMapper.AddTypeMap(typeof(int), DbType.Int32);
            SqlMapper.AddTypeHandler(new DateTimeHandler());
            SqlMapper.AddTypeHandler(new DateTimeNullableHandler());
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("Default");
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (_connection == null)
                    _connection = new SqlConnection(GetConnectionString());

                return _connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar corretamente ao servidor de banco de dados.", ex);
            }
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
