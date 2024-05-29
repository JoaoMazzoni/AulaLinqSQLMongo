using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Aula1BLinq
{

    public class Banco
    {
        static string connectionString = "Server=127.0.0.1; Database=DBPenalidadeMotorista; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";

        public static void InserirNoBanco(PenalidadesAplicadas penalidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Penalidade (RazaoSocial, CNPJ, NomeMotorista, CPF, VigenciaCadastro) VALUES (@RazaoSocial, @CNPJ, @NomeMotorista, @CPF, @VigenciaCadastro)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RazaoSocial", penalidade.RazaoSocial);
                    cmd.Parameters.AddWithValue("@CNPJ", penalidade.CNPJ);
                    cmd.Parameters.AddWithValue("@NomeMotorista", penalidade.NomeMotorista);
                    cmd.Parameters.AddWithValue("@CPF", penalidade.CPF);
                    cmd.Parameters.AddWithValue("@VigenciaCadastro", penalidade.VigenciaCadastro);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();

            }


        }


    }
}
