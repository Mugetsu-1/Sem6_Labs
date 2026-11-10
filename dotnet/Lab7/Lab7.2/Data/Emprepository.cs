using ADO.Models;
using System.Data;
using System.Data.SqlClient;

#pragma warning disable CS0618, CS8600, CS8601, CS8602, CS8604

namespace ADO.Data
{
    // All database logic lives here (Lab question 2).
    // The controller only calls these methods.
    public class Emprepository
    {
        private readonly string _connectionString;

        public Emprepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"] ?? string.Empty;
        }

        // Read all records using SqlDataAdapter + DataTable.
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                DataTable dataTable = new DataTable();
                string sql = "Select * From Employee";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                // filling records to DataTable
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Employee employee = new Employee
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = Convert.ToString(row["Name"]),
                        Department = Convert.ToString(row["Department"]),
                        Salary = Convert.ToDecimal(row["Salary"]),
                        City = Convert.ToString(row["City"]),
                        JoinedOn = Convert.ToDateTime(row["JoinedOn"])
                    };
                    employees.Add(employee);
                }
            }

            return employees;
        }

        // Read a single record using SqlDataReader.
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = $"Select * From Employee Where Id='{id}'";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        employee.Id = Convert.ToInt32(dataReader["Id"]);
                        employee.Name = Convert.ToString(dataReader["Name"]);
                        employee.Department = Convert.ToString(dataReader["Department"]);
                        employee.Salary = Convert.ToDecimal(dataReader["Salary"]);
                        employee.City = Convert.ToString(dataReader["City"]);
                        employee.JoinedOn = Convert.ToDateTime(dataReader["JoinedOn"]);
                    }
                }

                connection.Close();
            }

            return employee;
        }

        // Insert record using SqlConnection + SqlCommand.
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = $"Insert Into Employee (Name, Department, Salary, City) Values ('{employee.Name}', '{employee.Department}', '{employee.Salary}', '{employee.City}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        // Update record using SqlConnection + SqlCommand.
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = $"Update Employee SET Name='{employee.Name}', Department='{employee.Department}', Salary='{employee.Salary}', City='{employee.City}' Where Id='{employee.Id}'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        // Delete record using the DeleteEmployee stored procedure.
        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "DeleteEmployee";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}