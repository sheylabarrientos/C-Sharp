using Loja.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Loja.Test1
{
    public class ClienteModelTeste : ModeloBaseTeste
    {
        public ClienteModelTeste() : base(new LojaContext())
        {
            base.Tabela = "Cliente";
            base.Modelo = "Loja.Api.Models.Cliente";
        }

        [Fact]
        public void Devera_Ter_tabela()
        {
            CompararTabela();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            CompararPrimaryKeys("Endereco_Id");
        }

        [Theory]
        [InlineData("Id", false, typeof(int), null)]
        [InlineData("Name", false, typeof(string), 100)]
        [InlineData("Endereco_Id", false, typeof(int), null)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

        [Theory]
        [InlineData("Endereco_Id", false, "Enderecos", "Id")]
        public void Devera_Ter_FK(string campoNome, bool ehNulo, string tabelarelacionamento, string chaveRelacionamento)
        {
            CompararFK(campoNome, ehNulo, tabelarelacionamento, chaveRelacionamento);
        }

       
    }
}
