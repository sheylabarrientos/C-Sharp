using Loja.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Loja.Test
{
    public class ProdutoModelTest
    {
        private DbContext _context;
        private static string Tabela { get; } = "Produto";
        private static string Modelo { get; } = "Loja.Api.Models.Produto";

        public ProdutoModelTest() 
        {
            _context = new LojaContext();
        }
        
        //Cada m�todo dever� ter �nica e exclusiva fun��o

        private IEntityType GetEntity()
        {
            // prourar tipo da entidade
            return _context.Model.FindEntityType(Modelo);
        }

        private string GetNomeTabela(IEntityType entity)
        {
            //procurar a tabela atrav�s da entidade respectiva
            var annotation = entity.FindAnnotation("Relational:TableName");

            //retornar valor como string
            return annotation?.Value?.ToString();
        }

        private string GetNomeCampo(IProperty property)
        {
            //procurar  a proriedade coluna atrav�s da proriedade respectiva
            var annotation = property.FindAnnotation("Relational:ColumnName");

            //retornar valor como string
            return annotation?.Value?.ToString();
        }

        private IEnumerable<string> GetNomesCampos(IEntityType entity)
        {
            //procurar as propriedades atrav�s da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar a campos/colunas atrav�s das propriedades recuperadas 
            return propriedades?.Select(x => this.GetNomeCampo(x)).ToList();
        }

        private IEnumerable<string> GetPrimaryKeys(IEntityType entity)
        {
            //procurar as chaves atrav�s da entidade respectiva
            var chave = entity.FindPrimaryKey();

            //retornar o nome das chaves atrav�s das propriedades recuperadas
            return chave?.Properties.Select(x => this.GetNomeCampo(x)).ToList();
        }

        private void CompararPrimaryKeys(params string[] keys)
        {
            // buscar tipo da entidade
            var entity = GetEntity();
            // comparar se a entidade � nula
            Assert.NotNull(entity);

            // buscar chaves prim�rias da classe
            var chavesAtuais = GetPrimaryKeys(entity);
            
            //comparar se as chaves atuais � nula
            Assert.NotNull(chavesAtuais);
            
            //comparar se chave requerida est� na lista de chaves encontradas
            Assert.Contains(keys, x => chavesAtuais.Contains(x));
        }

        private IProperty ProcurarCampo(IEntityType entity, string campoNome)
        {
            //procurar as propriedades atrav�s da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar o campo esperado (vindo da compara��o dos campos das propriedades e o campo esperado)  com  atrav�s das propriedades recuperadas
            return propriedades.FirstOrDefault(x => this.GetNomeCampo(x) == campoNome);
        }

        private int GetTamanhoCampo(IProperty propriedade)
        {
            //retornar o tamanho da proriedade respectiva
            return propriedade.GetMaxLength().Value;
        }

        private void CompararCampos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            // buscar tipo da entidade
            var entity = GetEntity();
            //comparar se entidade � nula
            Assert.NotNull(entity);
            //comparar nome esperado nos nomes recuperados
            Assert.Contains(campoNome, GetNomesCampos(entity));

            //procurar propriedade atraves da entidade e o campo, para gerar objeto recuperado
            var propriedade = ProcurarCampo(entity, campoNome);
            
            // criar objeto esperado
            var esperado = new
            {
                tipo = campoTipo,
                nulo = ehNulo,
                tamanho = campoTamanho.HasValue ? campoTamanho.Value : 0
            }.ToString();

            // criar objeto recuperado
            var atual = new
            {
                tipo = propriedade.ClrType,
                nulo = propriedade.IsNullable,
                tamanho = campoTamanho.HasValue ? GetTamanhoCampo(propriedade) : 0
            }.ToString();

            //comparar o campo esperado com recuperado
            Assert.Equal(esperado, atual);
        }

        [Fact]
        public void Devera_Ter_tabela()
        {
            //// buscar tipo da entidade
            //var entidade = _context.Model.FindEntityType(Modelo);
            //// buscar nome da tabela dessa entidade
            //var annotation = entidade.FindAnnotation("Relational:TableName");
            //var tabelaAtual = annotation?.Value?.ToString();
            //// comparar se a entidade � nula
            //Assert.NotNull(entidade);
            //// comparar se a tabela pesquisa � igual a propriedade est�tica da classe 
            //Assert.Equal(Tabela, tabelaAtual);

            var entity = GetEntity();
            var atual = GetNomeTabela(entity);
            Assert.NotNull(entity);
            Assert.Equal(Tabela, atual);
        }


        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            //Definir chaves primarias
            string[] chaves = new string[]
            {
                "Id"
            };

            // buscar tipo da entidade
            var entidade = _context.Model.FindEntityType(Modelo);

            // buscar chaves prim�rias da classe
            var chave = entidade.FindPrimaryKey();
            var chavesAtuais = chave?.Properties.Select(x => this.GetNomeCampo(x)).ToList();

            // comparar se a entidade � nula
            Assert.NotNull(entidade);

            //comparar se as chaves atuais � nula
            Assert.NotNull(chavesAtuais);
            //comparar se chave requerida est� na lista de chaves encontradas
            Assert.Contains(chaves, x => chavesAtuais.Contains(x));

            CompararPrimaryKeys("Id");
        }

        

        [Theory]
        [InlineData("Id", false, typeof(int), null)]
        [InlineData("Name", false, typeof(string), 100)]
        [InlineData("Categoria", false, typeof(string), 50)]
        [InlineData("PrecoUnitario", false, typeof(decimal), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            // comparar campos esperados com campos recuperados
            CompararCampos(campoNome, ehNulo, campoTipo,  campoTamanho);
        }

       
    }
}
