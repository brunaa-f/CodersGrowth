
using Dominio;

namespace Infra
{
    public sealed class ListaSingleton
    {
        public static int idIncremental;
        private static List<Aluno> instancia;

        public static List<Aluno> obterInstancia()
        {
            if (instancia == null)
            {
                instancia = new List<Aluno>();
            }
            return instancia;
        }

        public static int NovoId()
        {
            return ++idIncremental;
        }
    }
}