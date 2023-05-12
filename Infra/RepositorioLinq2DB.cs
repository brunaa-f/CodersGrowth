using Dominio;
using LinqToDB.Data;
using LinqToDB;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    internal class RepositorioLinq2DB : IRepositorio
    {

        public void Atualizar(int id, Aluno alunoASerAtualizado)
        {
        }

        public void Criar(Aluno novoAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
