using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarAluno
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string NomeAluno { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno(int id, string nomeAluno, string cpf, string telefone, DateTime dataNascimento)
        {
            Id = id;
            NomeAluno=nomeAluno;
            Cpf=cpf;
            Telefone=telefone;
            DataNascimento=dataNascimento;
        }
        public Aluno() { }  
    }

}
