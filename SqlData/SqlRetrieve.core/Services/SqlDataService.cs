using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SqlRetrieve.Core.Interfaces;

namespace SqlRetrieve.Core.Services
{
    public class SqlDataService : IDataService
    {
        private readonly string _connectionString;

        public SqlDataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetNames()
        {
            var results = new List<string>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT Id, Name FROM [Training].[dbo].[Sample]", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                results.Add($"{id}-{name}"); 
            }
            return results;
        }
    }
}
