using System.Data;
using System.Data.SqlClient;

namespace Exo02_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO;Integrated Security=True;Encrypt=False;";

            #region Exo 1
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT ID, LastName, FirstName FROM V_student";
            //        connection.Open();
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                Console.WriteLine($"{(int)reader["ID"]} - {reader["LastName"].ToString()} {reader["FirstName"].ToString()}");
            //            }
            //        }
            //    }
            //}
            #endregion


            #region Exo 2
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT ID, SectionName FROM section";

            //        SqlDataAdapter adapter = new SqlDataAdapter();
            //        adapter.SelectCommand = command;

            //        DataTable table = new DataTable();
            //        adapter.Fill(table);

            //        foreach (DataRow row in table.Rows)
            //        {
            //            Console.WriteLine($"{(int)row["ID"]} - {row["SectionName"].ToString()}");
            //        }
            //    }
            //} 
            #endregion


            #region Exo 3
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT AVG(CONVERT(FLOAT,YearResult)) AS moyenne FROM V_student";
                    connection.Open();
                    double average = (double)command.ExecuteScalar();
                    Console.WriteLine($"La moyenne annuelle des étudiants est de {average}");
                }
            }
            #endregion
        }
    }
}
