﻿using Microsoft.Data.SqlClient;
using System;


namespace CadastrarAluno
{
    public class Conversor
    {
        public List<Aluno> Converter(SqlDataReader leitor)
        {

            List<Aluno> alunos = new List<Aluno>();
            while (leitor.Read())
            {
                Aluno aluno = new Aluno()
                {
                    Id = Convert.ToInt32(leitor["id"]),
                    NomeAluno = leitor["Nome"].ToString(),
                    Cpf = leitor["Cpf"].ToString(),
                    Telefone = leitor["Telefone"].ToString(),
                    DataNascimento = Convert.ToDateTime(leitor["Data_de_Nascimento"].ToString())
                };
                alunos.Add(aluno);
            }
            return alunos;
        }

        public Aluno BuscarPorId(SqlDataReader leitor)
        {
            if (leitor.Read())
            {
                Aluno buscarAluno = new Aluno()
                {
                    Id = Convert.ToInt32(leitor["id"]),
                    NomeAluno = leitor["Nome"].ToString(),
                    Cpf = leitor["Cpf"].ToString(),
                    Telefone = leitor["Telefone"].ToString(),
                    DataNascimento = Convert.ToDateTime(leitor["Data_de_Nascimento"].ToString()),
                };
                return buscarAluno;
            }
            else { return null; }
        }
            
    }
}

