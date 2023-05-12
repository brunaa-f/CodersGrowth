namespace Dominio
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }

        public Aluno(int id, string nome, string cpf, string telefone, DateTime nascimento)
        {
            Id = id;
            Nome=nome;
            Cpf=cpf;
            Telefone=telefone;
            Nascimento=nascimento;
        }
        public Aluno() {
        }  
    }
}
