
namespace CadastrarAluno
{
    public interface IRepositorio
    {
        public List<Aluno> ObterTodos();
        public void Criar(Aluno novoAluno);
        public void Atualizar(Aluno alunoASerAtualizado);
        public void Remover(int id);
        public Aluno ObterPorId(int id);
    }
}
