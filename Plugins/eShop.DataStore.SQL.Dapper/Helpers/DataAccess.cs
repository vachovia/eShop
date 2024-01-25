using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace eShop.DataStore.SQL.Dapper.Helpers
{
    public class DataAccess : IDataAccess
    {
        public readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<T>(sql, parameters);
            }
        }

        public T QueryFirst<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<T>(sql, parameters);
            }
        }

        public List<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        public void ExecuteCommand<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }
    }
}
