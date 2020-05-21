using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Api.Models.Configurations
{
    public class PromocaoProdutoConfiguration : IEntityTypeConfiguration<PromocaoProduto>
    {
        public void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            builder.HasKey(x => new { x.ProdutoId, x.PromocaoId });
        }
    }
}
