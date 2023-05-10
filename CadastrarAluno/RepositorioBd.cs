using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

namespace CadastrarAluno
{
    public class RepositorioBd : IRepositorio

    {
        private List<Aluno> lista = new List<Aluno>();


        public List<Aluno> ObterTodos()
        {
            if (lista.Count != decimal.Zero)
            {
                lista = new List<Aluno>();
            }

            using (var conexao = conectar())
            {
                try
                {
                    string sql = "SELECT * FROM tb_aluno";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
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
                    throw e;
                }
                return lista;
            }
        }

        public void Criar(Aluno novoAluno)
        {
            using (var conexao = conectar())
            {
                try
                {
                    string sql = "INSERT INTO tb_aluno (Nome, Cpf, Telefone, Data_de_Nascimento) VALUES (@Nome,@Cpf,@Telefone,@Data_de_Nascimento)";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

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
            }

        }

        public void Atualizar(int id, Aluno alunoASerAtualizado)
        {
            using (var conexao = conectar())
            {
                try
                {
                    conectar();
                    string sql = "UPDATE tb_aluno SET Nome = @Nome, Cpf = @Cpf, Telefone = @Telefone, Data_de_Nascimento = @Data_de_Nascimento WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@ID", alunoASerAtualizado.Id);
                    cmd.Parameters.AddWithValue("@Nome", alunoASerAtualizado.NomeAluno);
                    cmd.Parameters.AddWithValue("@Cpf", alunoASerAtualizado.Cpf);
                    cmd.Parameters.AddWithValue("@Telefone", alunoASerAtualizado.Telefone);
                    cmd.Parameters.AddWithValue("@Data_de_Nascimento", alunoASerAtualizado.DataNascimento);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public Aluno ObterPorId(int id)
        {
            var buscarAluno = new Aluno();

            using (var conexao = conectar())
            {
                try
                {
                    string sql = $"SELECT FROM tb_aluno Where Id= {id}";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        buscarAluno = new Aluno()
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            NomeAluno = dataReader["Nome"].ToString(),
                            Cpf = dataReader["Cpf"].ToString(),
                            Telefone = dataReader["Telefone"].ToString(),
                            DataNascimento = Convert.ToDateTime(dataReader["Data_de_Nascimento"].ToString()),
                        };
                    }
                    dataReader.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
                return buscarAluno;
            }

        }
        public void Remover(int id)
        {
            using (var conexao = conectar())
            {
                try
                {
                    string sql = $"DELETE FROM tb_aluno Where Id= {id}";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private SqlConnection conectar()
        {
            string conectionString = ConfigurationManager.ConnectionStrings["BancoDeAlunos"].ConnectionString;
            SqlConnection con = new SqlConnection(conectionString);
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return con;
        }
    }
}
