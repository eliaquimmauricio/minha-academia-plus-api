using Dapper;
using System.Data.SqlClient;

namespace Tasken.SRC.Infra.Data
{
    public abstract class BaseRepository
    {
        private readonly Context _context;
        private readonly int _commandTimeOut = 60;
        private SqlTransaction? _sqlTransaction;

        protected BaseRepository(Context context)
        {
            _context = context;
        }

        protected dynamic QueryFirstOrDefault(string sql, object? param = null)
        {
            return _context.GetConnection().QueryFirstOrDefault(sql, param, commandTimeout: _commandTimeOut, transaction: _sqlTransaction);
        }

        protected T QueryFirstOrDefault<T>(string sql, object? param = null)
        {
            return _context.GetConnection().QueryFirstOrDefault<T>(sql, param, commandTimeout: _commandTimeOut, transaction: _sqlTransaction);
        }

        protected List<T>? Query<T>(string sql, object? param = null)
        {
            return _context.GetConnection().Query<T>(sql, param, commandTimeout: _commandTimeOut, transaction: _sqlTransaction)?.ToList();
        }

        protected List<dynamic>? Query(string sql, object? param = null)
        {
            return _context.GetConnection().Query(sql, param, commandTimeout: _commandTimeOut, transaction: _sqlTransaction)?.ToList();
        }

        protected int Execute(string sql, object? param = null)
        {
            return _context.GetConnection().Execute(sql, param, commandTimeout: _commandTimeOut, transaction: _sqlTransaction);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
