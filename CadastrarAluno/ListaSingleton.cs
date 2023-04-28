
namespace CadastrarAluno
{
    public sealed class ListaSingleton
    {
        private static List<Aluno> instancia;
        public static List<Aluno> obterInstancia()
        {
            if (instancia == null)
            {
                instancia = new List<Aluno>();
            }
            return instancia;
        }
    }
}
