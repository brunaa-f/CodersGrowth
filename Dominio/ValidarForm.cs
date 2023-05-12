using Dominio;
using System.Text.RegularExpressions;


namespace CadastrarAluno.Servicos
{
    public class ValidarForm
    {
        public static bool Valida(Aluno aluno)
        {
            string erros = "";

            if (OCampoNaoPodeSerVazio(aluno.Nome))
            {
                erros += "O campo NOME deve ser preenchido!\n";
            }
            if (OCampoNaoPodeSerVazio(aluno.Cpf))
            {
                erros += "O campo CPF deve ser preenchido!\n";
            }
            if (OCampoNaoPodeSerVazio(aluno.Telefone))
            {
                erros += "O campo TELEFONE deve ser preenchido!\n";
            }
            if (ValidacaoDoCampoNome(aluno.Nome))
            {
                erros += "Digite um nome válido\n";
            }
            if (ValidacaoDoCampoCpf(aluno.Cpf))
            {
                erros += "CPF inválido \n";
            }
            if (ValidacaoDoCampoTelefone(aluno.Telefone))
            {
                erros += "Telefone inválido \n";
            }
            if (ValidacaoDoCampoDataNascimento(aluno.Nascimento))
            {
                erros += "Verifique a data de nascimento \n";
            }
            if (erros.Length > 0)
            {
                throw new Exception(erros);
            }

            return true;

        }
        private static bool OCampoNaoPodeSerVazio(string campo)
        {
            if (campo == "")
            {
                return true;
            }
            return false;
        }

        private static bool ValidacaoDoCampoNome(string nome)
        {
            if (nome.Length < 2 || nome.Length > 70)
            {
                return true;
            }

            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            if (!regex.IsMatch(nome))
            {
                return true;
            }

            return false;
        }
        private static bool ValidacaoDoCampoCpf(string cpf)
        {
            Regex regex = new Regex("([0-9]{2}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[\\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[-]?[0-9]{2})");
            if (!regex.IsMatch(cpf))
            {
                return true;
            }

            return false;
        }
        private static bool ValidacaoDoCampoTelefone(string telefone)
        {
            Regex regex = new Regex("^(?:\\(\\d{2}\\)|\\d{2})[- ]?\\d{4,5}[- ]?\\d{4}$");
            if (!regex.IsMatch(telefone))
            {
                return true;
            }
            return false;
        }
        private static bool ValidacaoDoCampoDataNascimento(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Now || idade < 11 || idade > 120)
            {
                return true;
            }
            return false;
        }

        public static class GeradorDeIds
        {
            private static int _ultimoId = 0;
            public static int NovoId()
            {
                return ++_ultimoId;
            }
        }
    }
}