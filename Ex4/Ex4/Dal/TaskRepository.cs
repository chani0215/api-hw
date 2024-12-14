using Microsoft.Data.SqlClient;
using System.Data;

namespace Ex4.Dal
{
    public class TaskRepository
    {
        string connect;
        public TaskRepository(IConfiguration configuration)
        {
            connect = configuration.GetConnectionString("DefaultConnection");
        }
        public DataTable GetTasksByUser(int userId)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Tasks_GetTasksByUser";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("@UserId", userId);
                    command.Parameters.Add(sqlParameter);
                    connection.Open();

                    using(SqlDataAdapter da=new SqlDataAdapter(command))
                    {
                        da.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}
