using Dominio;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using LinqToDB.DataProvider.SqlServer;


namespace Infra
{
    public class RepositorioLinq2DB : IRepositorio
    {
        private DataConnection CriarConexao()
        {
            try
            {
                string conectionString = ConfigurationManager.ConnectionStrings["BancoDeAlunos"].ConnectionString;
                var conexao = SqlServerTools.CreateDataConnection(conectionString);
                return conexao;
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Atualizar(int id, Aluno alunoASerAtualizado)
        {

            using (var conexaoLinq2Db = CriarConexao())
            {
                try
                {
                    conexaoLinq2Db.Update(alunoASerAtualizado);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public void Criar(Aluno novoAluno)
        {
            using (var conexaoLinq2Db = CriarConexao())
            {
                try
                { 
                    novoAluno.Id = conexaoLinq2Db.InsertWithInt32Identity(novoAluno);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public Aluno ObterPorId(int id)
        {
            using (var conexaoLinq2Db = CriarConexao())
            {
                try
                {
                    var ObterAlunoPorId = conexaoLinq2Db.GetTable<Aluno>().FirstOrDefault(a => a.Id == id);
                    return ObterAlunoPorId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public List<Aluno> ObterTodos()
        {
            using (var conexaoLinq2Db = CriarConexao())
            {
                try
                {
                    var obterAlunos = conexaoLinq2Db.GetTable<Aluno>().ToList();
                    return obterAlunos;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public void Remover(int id)
        {
            using (var conexaoLinq2Db = CriarConexao())
            {
                try
                {
                    conexaoLinq2Db.GetTable<Aluno>().Where(t => t.Id == id).Delete();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
