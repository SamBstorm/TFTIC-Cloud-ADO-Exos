using System.Data.SqlClient;

namespace Exo03_ADO_DML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO;Integrated Security=True;Encrypt=False;";

            Student stu = new Student() { 
                LastName = "Legrain",
                FirstName = "Samuel",
                BirthDate = new DateTime(1987,9,27),
                SectionId = 1120,
                Active = true
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO [student] ([LastName],[FirstName],[BirthDate],[YearResult],[SectionId], [Active]) OUTPUT [inserted].[ID] VALUES ('{stu.LastName}','{stu.FirstName}','{stu.BirthDate.ToString("yyyy-MM-dd")}',{stu.YearResult}, {stu.SectionId}, {((stu.Active)?1:0)})";
                    Console.WriteLine(command.CommandText);
                    connection.Open();
                    stu.ID = (int) command.ExecuteScalar();
                    Console.WriteLine($"L'étudiant {stu.FirstName} {stu.LastName} a comme ID {stu.ID}");
                }
            }
        }

        static string ConvertToSQL(DateTime date)
        {
            return $"'{date.Year}-{((date.Month<10)?"0":"")}{date.Month}-{((date.Day < 10) ? "0" : "")}{date.Day}'";
        }
    }
}