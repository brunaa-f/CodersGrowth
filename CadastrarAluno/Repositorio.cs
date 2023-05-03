
namespace CadastrarAluno
{
    public class Repositorio : IRepositorio
    {
        protected List<Aluno> listaAlunos = ListaSingleton.obterInstancia();

        public List<Aluno> ObterTodos()
        {
            return listaAlunos;
        }

        public void Criar(Aluno novoAluno)
        {
            ListaSingleton.obterInstancia().Add(novoAluno);
            ListaSingleton.NovoId();
        }
        public void Remover(int id)
        {
            var alunoARemover = ObterPorId(id);
            ListaSingleton.obterInstancia().Remove(alunoARemover);
        }

        public void Atualizar(Aluno alunoASerAtualizado)
        {
            foreach (Aluno aluno in ListaSingleton.obterInstancia())
            {
                if (aluno.Id == alunoASerAtualizado.Id)
                {
                    aluno.NomeAluno = alunoASerAtualizado.NomeAluno;
                    aluno.Cpf = alunoASerAtualizado.Cpf;
                    aluno.Telefone = alunoASerAtualizado.Telefone;
                    aluno.DataNascimento = alunoASerAtualizado.DataNascimento;
                }
            }
        }

        public Aluno ObterPorId(int id)
        {
            foreach (Aluno aluno in ListaSingleton.obterInstancia())
            {
                if (aluno.Id == id)
                {
                    return aluno;
                }
            }
            return null;
        }
    }
}
