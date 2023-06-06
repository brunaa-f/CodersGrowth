
using LinqToDB.Mapping;

namespace Dominio
{
    public class Aluno
    {
        [PrimaryKey, Identity] public int Id { get; set; }
        [NotNull] public string Nome { get; set; }
        [NotNull] public string Cpf { get; set; }
        [NotNull] public string Telefone { get; set; }
        [NotNull] public DateTime Nascimento { get; set; }

        public Aluno() {
        }  

        public Aluno(int id, string nome, string cpf, string telefone, DateTime nascimento)
        {
            Id = id;
            Nome=nome;
            Cpf=cpf;
            Telefone=telefone;
            Nascimento=nascimento;
        }
    }
}
