
using Dominio;

namespace Infra
{
    public class Repositorio : IRepositorio
    {
        protected List<Aluno> _listaAlunos = ListaSingleton.obterInstancia();


        public List<Aluno> ObterTodos()
        {
            return _listaAlunos.ToList();
        }

        public void Criar(Aluno novoAluno)
        {
            _listaAlunos.Add(novoAluno);
        }

        public void Remover(int id)
        {
            var alunoARemover = ObterPorId(id);
            _listaAlunos.Remove(alunoARemover);
        }

        public void Atualizar(int IdAluno, Aluno alunoASerAtualizado)
        {
            var index = _listaAlunos.FindIndex(x => x.Id == IdAluno);
            _listaAlunos[index] = alunoASerAtualizado;
        }

        public Aluno ObterPorId(int id)
        {
            var alunoBuscado = _listaAlunos.FirstOrDefault(x => x.Id == id);
            return alunoBuscado;
        }
    }
}
