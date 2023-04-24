﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CadastrarAluno.Services
{
    public class ValidarForm
    {
        public static bool Valida(Aluno aluno)
        {
            string erros = "";

            if (OCampoNaoPodeSerVazio(aluno.NomeAluno))
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
            if (ValidacaoDoCampoNome(aluno.NomeAluno))
            {
                erros += "Digite um nome válido\n";
            }
            if (ValidacaoDoCampoCpf(aluno.Cpf))
            {
                erros += "CPF inválido \n";
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

    }
}

