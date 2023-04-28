using Microsoft.Data.SqlClient;

namespace DataAcess {
    internal class Program {
        static void Main(string[] args) {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=root;TrustServerCertificate=True";
            ////PRIMEIRA FORMA DE USAR A CONEXAO COM O BANCO DE DADOS
            //var connection = new SqlConnection();
            //connection.Open();
            ////INSERT
            ////UPDATE
            //connection.Close();
            //connection.Dispose(); // DESTROI A CONEXAO, PRECISA ESTANCIAR NOVAMENTE

            //SEGUNDA FORMA DE USAR A CONEXAO COM O BANCO DE DADOS
            using (var connection = new SqlConnection(connectionString)) {
                Console.WriteLine("Conectado");
                connection.Open();
                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
                connection.Close();

            }
            Console.ReadLine();
        }
    }
}