using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Loja.Test1
{
    //classe base para testes de modelo - poderá ser utilizada para testes de todas as classes de modelo
    //abstrata pois não será instanciada
    public abstract class ModeloBaseTeste
    {
        private DbContext _context;

        //propriedades que serão preenchidas nas classes derivadas
        protected string Tabela { get; set;  } 
        protected string Modelo { get; set;  }

        // não é de responsalidade da classe Modelo instanciar o contexto
        public ModeloBaseTeste(DbContext contexto)
        {
            _context = contexto;
        }

        private IEntityType GetEntity()
        {
            return _context.Model.FindEntityType(Modelo);
        }

        private IEntityType GetEntity(string nomeTabela)
        {
            //retornar o tipo que corresponda a nomeTabela 
            return _context.Model.GetEntityTypes().FirstOrDefault(x => GetNomeTabela(x) == nomeTabela);
        }

        private string GetNomeTabela(IEntityType entity)
        {
            var annotation = entity.FindAnnotation("Relational:TableName");
            return annotation?.Value?.ToString();
        }

        private string GetNomeCampo(IProperty property)
        {
            var annotation = property.FindAnnotation("Relational:ColumnName");

            return annotation?.Value?.ToString();
        }

        private IEnumerable<string> GetNomesCampos(IEntityType entity)
        {
            var propriedades = entity.GetProperties();

            return propriedades?.Select(x => this.GetNomeCampo(x)).ToList();
        }

        private IEnumerable<string> GetPrimaryKeys(IEntityType entity)
        {
            var chave = entity.FindPrimaryKey();
            return chave?.Properties.Select(x => this.GetNomeCampo(x)).ToList();
        }

        protected void CompararPrimaryKeys(params string[] keys)
        {
            var entity = GetEntity();
            Assert.NotNull(entity);

            var chavesAtuais = GetPrimaryKeys(entity);
            Assert.NotNull(chavesAtuais);
            Assert.Contains(keys, x => chavesAtuais.Contains(x));
        }

        private IProperty ProcurarCampo(IEntityType entity, string campoNome)
        {
            var propriedades = entity.GetProperties();
            return propriedades.FirstOrDefault(x => this.GetNomeCampo(x) == campoNome);
        }

        private int GetTamanhoCampo(IProperty propriedade)
        {
            return propriedade.GetMaxLength().Value;
        }

        protected void CompararCampos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            var entity = GetEntity();
            Assert.NotNull(entity);
            Assert.Contains(campoNome, GetNomesCampos(entity));

            var propriedade = ProcurarCampo(entity, campoNome);

            var esperado = new
            {
                tipo = campoTipo,
                nulo = ehNulo,
                tamanho = campoTamanho.HasValue ? campoTamanho.Value : 0
            }.ToString();

            var atual = new
            {
                tipo = propriedade.ClrType,
                nulo = propriedade.IsNullable,
                tamanho = campoTamanho.HasValue ? GetTamanhoCampo(propriedade) : 0
            }.ToString();

            Assert.Equal(esperado, atual);
        }

        protected void CompararTabela()
        {
            var entity = GetEntity();
            var atual = GetNomeTabela(entity);
            Assert.NotNull(entity);
            Assert.Equal(Tabela, atual);
        }


        protected void CompararFK(string campoNome, bool ehNulo, string tabelarelacionamentoEsperado, params string[] chaveRelacionamentoEsperadas)
        {
            // prourar tipo da entidade
            var entity = GetEntity();
            Assert.NotNull(entity);

            //sobrecarga de método
            //retornar o tipo que corresponda a Tabela esperada
            var relacionamentoEntity = GetEntity(tabelarelacionamentoEsperado);
            Assert.NotNull(relacionamentoEntity);

            //Assert.Contains(campoNome, GetNomesCampos(entity));
            var propriedade = ProcurarCampo(entity, campoNome);
            Assert.NotNull(propriedade);

            // procurar FK na entidade e selecionar a que corresponde ao relacionamento recuperado
            var foreignKey = entity.FindForeignKeys(propriedade).FirstOrDefault(x => x.PrincipalEntityType == relacionamentoEntity);
            Assert.NotNull(foreignKey);
            Assert.Equal(ehNulo, !foreignKey.IsRequired);

            //comparar as proriedades da FK anterior com as FK esperadas
            var chavesAtuais = foreignKey.PrincipalKey.Properties.Select(x => GetNomeCampo(x));
            Assert.Contains(chaveRelacionamentoEsperadas, x => chavesAtuais.Contains(x));


        }
    }
}
