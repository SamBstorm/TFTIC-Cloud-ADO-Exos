using System.Data.SqlClient;

namespace Exo04_ADO_Parameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO;Integrated Security=True;Encrypt=False;";

            Student student = new Student() { 
                LastName = "Norris",
                FirstName = "Chuck",
                BirthDate = new DateTime(1940,3,10),
                YearResult = 20,
                SectionId = 1120
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = "INSERT INTO student (LastName, FirstName, BirthDate, YearResult, SectionId) OUTPUT inserted.ID, inserted.Active VALUES (@LastName, @FirstName, @BirthDate, @YearResult, @SectionId)";
                    /*
                    SqlParameter p1 = new SqlParameter() { 
                        ParameterName = nameof(Student.LastName),
                        Value = student.LastName
                    };
                    SqlParameter p2 = new SqlParameter()
                    {
                        ParameterName = nameof(Student.FirstName),
                        Value = student.FirstName
                    };
                    SqlParameter p3 = new SqlParameter()
                    {
                        ParameterName = nameof(Student.BirthDate),
                        Value = student.BirthDate
                    };
                    SqlParameter p4 = new SqlParameter()
                    {
                        ParameterName = nameof(Student.YearResult),
                        Value = student.YearResult
                    };
                    SqlParameter p5 = new SqlParameter()
                    {
                        ParameterName = nameof(Student.SectionId),
                        Value = student.SectionId
                    };
                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);
                    command.Parameters.Add(p5);
                    */

                    command.Parameters.AddWithValue(nameof(Student.LastName), student.LastName);
                    command.Parameters.AddWithValue(nameof(Student.FirstName), student.FirstName);
                    command.Parameters.AddWithValue(nameof(Student.BirthDate), student.BirthDate);
                    command.Parameters.AddWithValue(nameof(Student.YearResult), student.YearResult);
                    command.Parameters.AddWithValue(nameof(Student.SectionId), student.SectionId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            student.ID = (int)reader[nameof(Student.ID)];
                            student.Active = (bool)reader[nameof(Student.Active)];
                            Console.WriteLine($"L'étudiant {student.FirstName} {student.LastName} a l'identifiant {student.ID} et est actif : {student.Active}.");
                        }
                        else
                        {
                            Console.WriteLine("Enregistrement échoué...");
                        }
                    }
                }
            }
        }
    }
}
