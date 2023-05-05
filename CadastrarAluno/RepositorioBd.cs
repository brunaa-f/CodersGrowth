using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace CadastrarAluno
{
    public class RepositorioBd : IRepositorio
    {

        private static string conectionString = ConfigurationManager.ConnectionStrings["BancoDeAlunos"].ConnectionString;
        SqlConnection con = new SqlConnection(conectionString);
        SqlCommand cmd = new SqlCommand();

        private SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        private SqlConnection desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }

        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Criar(Aluno novoAluno)
        {
            var conexao = conectar();
            List<Aluno> alunos = new List<Aluno>();
            var sql = "INSERT INTO tb_aluno (Nome Aluno, CPF, Telefone, Data de Nascimento)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Nome Aluno", );
            cmd.ExecuteNonQuery();
            cmd.Connection = desconectar();
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
    }
}

