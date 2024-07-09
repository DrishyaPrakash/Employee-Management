using ARSPracticeEMS.ConnectionString;
using ARSPracticeEMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ARSPracticeEMS.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("ConnectionString");
        }
        public async Task<ActionResult<IEnumerable<EmpDeptViewModel>>> AllEmployees()
        {
            try
            {
                List<EmpDeptViewModel> employees = new List<EmpDeptViewModel>();
                using (SqlConnection con = new SqlConnection(this._connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAllEployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmpDeptViewModel emp = new EmpDeptViewModel();
                        emp.EmpId = Convert.ToInt32(reader["EmpId"]);
                        emp.FirstName = reader["FirstName"].ToString();
                        emp.LastName = reader["LastName"].ToString();
                        emp.DepartmentName = reader["DepartmentName"].ToString();
                        emp.EmployeeType = reader["EmployeeType"].ToString();
                        emp.DateOfJoining = Convert.ToDateTime(reader["DateOfJoining"]);

                        employees.Add(emp);
                    }
                    con.Close();
                }
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this._connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);
                    cmd.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                    cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<ActionResult<bool>> EmployeeExistence(Employee emp)
        {
            try
            {
                int check = 0;
                using (SqlConnection con = new SqlConnection(this._connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spEmployeeExistence", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName",emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", emp.LastName);

                    SqlParameter exist=new SqlParameter("@Exist",SqlDbType.Int);
                    exist.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(exist);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    if(exist.Value!=DBNull.Value)
                    {
                        check= Convert.ToInt32(exist.Value);
                    }

                    con.Close();

                    if (check == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
