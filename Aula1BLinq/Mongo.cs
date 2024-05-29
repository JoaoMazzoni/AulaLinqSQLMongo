
using Microsoft.Data.SqlClient;
using MongoDB.Driver;

namespace Aula1BLinq
{
    public class Mongo
    {
        static string sqlConnectionString = "Server=127.0.0.1; Database=DBPenalidadeMotorista; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";
        static string mongoConnectionString = "mongodb://root:Mongo%402024%23@localhost:27017";
        static string mongoDatabaseName = "DBPenalidadeMotorista";
        static string mongoCollectionName = "Penalidade";
        static SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

        public static void TransferirDadosParaMongo()
        {
            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
            var mongoCollection = mongoDatabase.GetCollection<PenalidadesAplicadas>(mongoCollectionName);

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                sqlConnection.Open();
                string sqlQuery = "SELECT RazaoSocial, CNPJ, NomeMotorista, CPF, VigenciaCadastro FROM Penalidade";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var penalidade = new PenalidadesAplicadas
                        {
                            RazaoSocial = reader["RazaoSocial"].ToString(),
                            CNPJ = reader["CNPJ"].ToString(),
                            NomeMotorista = reader["NomeMotorista"].ToString(),
                            CPF = reader["CPF"].ToString(),
                            VigenciaCadastro = (DateTime)reader["VigenciaCadastro"]
                        };


                        mongoCollection.InsertOne(penalidade);
                    }
                }
            }

            Console.WriteLine("Dados transferidos para o MongoDB com sucesso.");
        }

        public static void TransferirMetaDadoSQL()
        {
            sqlConnection.Open();
            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoCollection = mongoClient.GetDatabase(mongoDatabaseName).GetCollection<PenalidadesAplicadas>(mongoCollectionName);
            var numberOfRecords = mongoCollection.CountDocuments(count => true);

            using (var sqlCommand = new SqlCommand("INSERT INTO MetaDado (Description, NumberOfRecords) VALUES (@Description, @NumberOfRecords)", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Description", "Dados transferidos do MongoDB");
                sqlCommand.Parameters.AddWithValue("@NumberOfRecords", numberOfRecords);
                sqlCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Dados transferidos para o SQL Server com sucesso.");
        }



    }
}