using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjAdoExample
{
    //Arquitetura Data Access Object - isolar toda responsabilidade do banco de dados
    public class ProdutoDAO : IDisposable   
    {
        private IDbConnection _conexao;
        public ProdutoDAO()
        {
            //provider - especificas do banco de dados - SqlConnection = Para SQL Server
            _conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LojaDb;Trusted_Connection=True");
        }

        // CRUD - Create, Read, Update e Delete

        //CREATE
        public void Adicionar(Produto p)
        {
            try
            {
                //linguagem sql
                IDbCommand insertCmd = _conexao.CreateCommand();
                
                //string de comando
                insertCmd.CommandText = "INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)";

                //preencher os parametros
                IDbDataParameter paramNome = new SqlParameter("nome", p.Nome);
                insertCmd.Parameters.Add(paramNome);

                IDbDataParameter paramCategoria = new SqlParameter("categoria", p.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                IDbDataParameter paramPreco = new SqlParameter("preco", p.Preco);
                insertCmd.Parameters.Add(paramPreco);

                //executar o comando
                insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        //update
        public void Atualizar(Produto p)
        {
            try
            {
                var updateCmd = _conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Produtos SET Nome = @nome, Categoria = @categoria, Preco = @preco WHERE Id = @id";

                var paramNome = new SqlParameter("nome", p.Nome);
                var paramCategoria = new SqlParameter("categoria", p.Categoria);
                var paramPreco = new SqlParameter("preco", p.Preco);
                var paramId = new SqlParameter("id", p.Id);

                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramCategoria);
                updateCmd.Parameters.Add(paramPreco);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        //Delete
        public void Remover(Produto p)
        {
            try
            {
                var deleteCmd = _conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Produtos WHERE Id = @id";

                var paramId = new SqlParameter("id", p.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        //Read
        public IList<Produto> Produtos()
        {
            var lista = new List<Produto>();

            var selectCmd = _conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Produtos";

            var resultado = selectCmd.ExecuteReader();

            while (resultado.Read())
            {
                Produto p = new Produto();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Nome = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.Preco = Convert.ToDouble(resultado["Preco"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }

        //liberar recursos
        public void Dispose()
        {
            _conexao.Close();
        }
    }
}
