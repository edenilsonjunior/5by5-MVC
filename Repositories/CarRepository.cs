using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace Repositories
{
    public class CarRepository
    {
        private static readonly string _connStr = "Data Source=127.0.0.1; Initial Catalog=DBCar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";

        private readonly SqlConnection _conn;

        public CarRepository()
        {
            _conn = new SqlConnection(_connStr);
            _conn.Open();
        }

        public bool Insert(Car car)
        {
            var cmd = new SqlCommand(Car.INSERT, _conn)
            {
                Parameters =
                {
                    new SqlParameter("@name", car.Name),
                    new SqlParameter("@color", car.Color),
                    new SqlParameter("@year", car.Year),
                    new SqlParameter("@insurance_id", car.Insurance.Id),
                }
            };


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Erro SQL: {e.Message}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return false;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return true;
        }

        public bool Updade(Car car)
        {

            var cmd = new SqlCommand(Car.UPDATE, _conn)
            {
                Parameters =
                {
                    new SqlParameter("@name", car.Name),
                    new SqlParameter("@color", car.Color),
                    new SqlParameter("@year", car.Year),
                    new SqlParameter("@id", car.Id)
                }
            };

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Erro SQL: {e.Message}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return false;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return true;
        }

        public bool Delete(int id)
        {
            var cmd = new SqlCommand(Car.DELETE, _conn)
            {
                Parameters =
                {
                    new SqlParameter("@id", id)
                }
            };

            try
            {
                int result = cmd.ExecuteNonQuery();

                if (result == 0) return false;
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Erro SQL: {e.Message}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return false;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return true;
        }

        public List<Car> GetAll()
        {
            var list = new List<Car>();

            try
            {
                using var cmd = new SqlCommand(Car.GETALL, _conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var car = new Car();
                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);

                    list.Add(car);
                }
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

            return list;
        }

        public Car? Get(int id)
        {
            Car? car = null;
            try
            {
                using var cmd = new SqlCommand(Car.GET, _conn);
                cmd.Parameters.Add(new SqlParameter("@id", id));

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    car = new Car();
                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);
                }
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
            return car;
        }

    }
}
