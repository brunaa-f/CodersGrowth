
using Dominio;

namespace Infra
{
    public interface IRepositorio
    {
        public List<Aluno> ObterTodos();
        public void Criar(Aluno novoAluno);
        public void Atualizar(int id, Aluno alunoASerAtualizado);
        public void Remover(int id);
        public Aluno ObterPorId(int id);
    }
}
