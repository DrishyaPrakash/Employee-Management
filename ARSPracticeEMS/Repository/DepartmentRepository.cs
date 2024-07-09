using ARSPracticeEMS.ConnectionString;
using ARSPracticeEMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ARSPracticeEMS.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("ConnectionString");
        }

        public async Task<ActionResult<IEnumerable<Department>>> AllDepartments()
        {
            try
            {
               
                using (SqlConnection con = new SqlConnection(this._connectionString))
                {
                    List<Department> departments = new List<Department>();
                    SqlCommand cmd = new SqlCommand("spAllDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Department dept = new Department();
                        dept.DeptNo = Convert.ToInt32(reader["DeptNo"].ToString());
                        dept.DepartmentName = reader["DepartmentName"].ToString();

                        departments.Add(dept);
                    }
                    con.Close();
                    return departments;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
