using System.Data.SqlClient;

namespace ARSPracticeEMS.ConnectionString
{
    public class SQLConnection
    {
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = null;
            try
            {
                string connectionString= "Server=LAPTOP-QCIMBJLK\\SQLEXPRESS; Database=ARSPracticeDb; Trusted_Connection=True; TrustServerCertificate=True";
                if(connection==null || Convert.ToString(connection.State) == "closed")
                {
                    connection=new SqlConnection(connectionString);
                }
                return connection;
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Exception: "+ex.Message);
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
