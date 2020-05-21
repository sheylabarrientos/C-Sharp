using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServices.Api.Models.Configurations
{
    public class PromocaoProdutoConfiguration : IEntityTypeConfiguration<PromocaoProduto>
    {
        public void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Produto)
                .WithMany(x => x.Promocoes)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produto_Promocao");

            builder.HasOne(p => p.Promocao)
                .WithMany(d => d.PromocaoProdutos)
                .HasForeignKey(x => x.PromocaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Promocao_Produto");
        }
    }
}
