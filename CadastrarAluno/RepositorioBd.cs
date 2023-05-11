using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CadastrarAluno
{
    public class RepositorioBd : IRepositorio

    {
        private List<Aluno> lista = new List<Aluno>();


        public List<Aluno> ObterTodos()
        {
            using (var conexao = conectar())
            {
                try
                {
                    Conversor conversor = new Conversor();
                    string sql = "SELECT * FROM tb_aluno";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    SqlDataReader leitor = cmd.ExecuteReader();
                    lista = conversor.Converter(leitor);
                    return lista;
                }
                catch (Exception e)
                {
                    throw e;
                }
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
                    Conversor conversor = new Conversor();
                    string sql = $"SELECT FROM tb_aluno Where Id= {id}";
                    SqlCommand cmd = new SqlCommand(sql, conexao);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader leitor = cmd.ExecuteReader();
                    buscarAluno = conversor.BuscarPorId(leitor);
                    return buscarAluno;
                }
                catch (Exception e)
                {
                    throw e;
                }
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
            try
            {
            string conectionString = ConfigurationManager.ConnectionStrings["BancoDeAlunos"].ConnectionString;
            SqlConnection conexao = new SqlConnection(conectionString);
            conexao.Open();
            return conexao;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
