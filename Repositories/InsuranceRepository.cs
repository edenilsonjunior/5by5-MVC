using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace Repositories
{
    public class InsuranceRepository
    {
        private static readonly string _connStr = "Data Source=127.0.0.1; Initial Catalog=DBCar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";

        private readonly SqlConnection _conn;

        public InsuranceRepository()
        {
            _conn = new SqlConnection(_connStr);
            _conn.Open();
        }

        public int Insert(Insurance insurance)
        {
            int result = 0;

            var cmd = new SqlCommand(Insurance.INSERT, _conn);
            cmd.Parameters.Add(new SqlParameter("@description", insurance.Description));


            try
            {
                result = (int)cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Erro SQL: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return result;
        }
    }
}
