using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace CadastrarAluno
{
    public class RepositorioBd : IRepositorio

    {
        private static string conectionString = ConfigurationManager.ConnectionStrings["BancoDeAlunos"].ConnectionString;
        SqlConnection con = new SqlConnection(conectionString);
        SqlCommand cmd = new SqlCommand();

        public void Criar(Aluno novoAluno)
        {

            try
            {
                conectar();
                string sql = "INSERT INTO tb_aluno (Nome, Cpf, Telefone, Data_de_Nascimento) VALUES (@Nome,@Cpf,@Telefone,@Data_de_Nascimento)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Nome", novoAluno.NomeAluno);
                cmd.Parameters.AddWithValue("@Cpf", novoAluno.Cpf);
                cmd.Parameters.AddWithValue("@Telefone", novoAluno.Telefone);
                cmd.Parameters.AddWithValue("@Data_de_Nascimento", novoAluno.DataNascimento);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();  

            }
            catch (SqlException e)
            {
            }
            finally
            {
                desconectar();
            }
        }


        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Aluno alunoASerAtualizado)
        {

            throw new NotImplementedException();
        }


        public Aluno ObterPorId(int id)
        {
            throw new NotImplementedException();
        }


        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        private SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

