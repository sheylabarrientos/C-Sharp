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
        
        //Cada método deverá ter única e exclusiva função

        private IEntityType GetEntity()
        {
            // prourar tipo da entidade
            return _context.Model.FindEntityType(Modelo);
        }

        private string GetNomeTabela(IEntityType entity)
        {
            //procurar a tabela através da entidade respectiva
            var annotation = entity.FindAnnotation("Relational:TableName");

            //retornar valor como string
            return annotation?.Value?.ToString();
        }

        private string GetNomeCampo(IProperty property)
        {
            //procurar  a proriedade coluna através da proriedade respectiva
            var annotation = property.FindAnnotation("Relational:ColumnName");

            //retornar valor como string
            return annotation?.Value?.ToString();
        }

        private IEnumerable<string> GetNomesCampos(IEntityType entity)
        {
            //procurar as propriedades através da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar a campos/colunas através das propriedades recuperadas 
            return propriedades?.Select(x => this.GetNomeCampo(x)).ToList();
        }

        private IEnumerable<string> GetPrimaryKeys(IEntityType entity)
        {
            //procurar as chaves através da entidade respectiva
            var chave = entity.FindPrimaryKey();

            //retornar o nome das chaves através das propriedades recuperadas
            return chave?.Properties.Select(x => this.GetNomeCampo(x)).ToList();
        }

        private void CompararPrimaryKeys(params string[] keys)
        {
            // buscar tipo da entidade
            var entity = GetEntity();
            // comparar se a entidade é nula
            Assert.NotNull(entity);

            // buscar chaves primárias da classe
            var chavesAtuais = GetPrimaryKeys(entity);
            
            //comparar se as chaves atuais é nula
            Assert.NotNull(chavesAtuais);
            
            //comparar se chave requerida está na lista de chaves encontradas
            Assert.Contains(keys, x => chavesAtuais.Contains(x));
        }

        private IProperty ProcurarCampo(IEntityType entity, string campoNome)
        {
            //procurar as propriedades através da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar o campo esperado (vindo da comparação dos campos das propriedades e o campo esperado)  com  através das propriedades recuperadas
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
            //comparar se entidade é nula
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
            //// comparar se a entidade é nula
            //Assert.NotNull(entidade);
            //// comparar se a tabela pesquisa é igual a propriedade estática da classe 
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

            // buscar chaves primárias da classe
            var chave = entidade.FindPrimaryKey();
            var chavesAtuais = chave?.Properties.Select(x => this.GetNomeCampo(x)).ToList();

            // comparar se a entidade é nula
            Assert.NotNull(entidade);

            //comparar se as chaves atuais é nula
            Assert.NotNull(chavesAtuais);
            //comparar se chave requerida está na lista de chaves encontradas
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
