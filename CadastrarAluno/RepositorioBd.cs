using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace CadastrarAluno
{
    public class RepositorioBd : IRepositorio

    {
        private List<Aluno> lista = new List<Aluno>();
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
            catch (Exception e)
            {
                throw e;
            }
            finally
            { desconectar(); }
        }


        public List<Aluno> ObterTodos()
        {
            if (lista.Count != decimal.Zero)
            {
                lista = new List<Aluno>();
            }

            try
            {
                conectar();
                string sql = "SELECT * FROM tb_aluno";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    lista.Add(new Aluno()
                    {
                        Id = Convert.ToInt32(dataReader["id"]),
                        NomeAluno = dataReader["Nome"].ToString(),
                        Cpf = dataReader["Cpf"].ToString(),
                        Telefone = dataReader["Telefone"].ToString(),
                        DataNascimento = Convert.ToDateTime(dataReader["Data_de_Nascimento"].ToString()),
                    });
                }

                dataReader.Close();
                return lista;
            }
            catch (Exception e)
            {
            }
            finally { desconectar(); }
            return lista;
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

