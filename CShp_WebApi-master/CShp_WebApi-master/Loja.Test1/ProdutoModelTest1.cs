using Loja.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Loja.Test1
{
    public class ProdutoModelTest1 : ModeloBaseTeste
    {
        public ProdutoModelTest1() : base(new LojaContext())
        {
            base.Tabela  = "Produto";
            base.Modelo  = "Loja.Api.Models.Produto";
        }

        [Fact]
        public void Devera_Ter_tabela()
        {
            CompararTabela();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            CompararPrimaryKeys("Id");
        }

        [Theory]
        [InlineData("Id", false, typeof(int), null)]
        [InlineData("Name", false, typeof(string), 100)]
        [InlineData("Categoria", false, typeof(string), 50)]
        [InlineData("PrecoUnitario", false, typeof(decimal), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }
    }
}
