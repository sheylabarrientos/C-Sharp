﻿// <auto-generated />
using System;
using LojaServices.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaServices.Migrations
{
    [DbContext(typeof(LojaContext))]
    partial class LojaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaServices.Api.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnderecoId")
                        .HasColumnName("Endereco_Id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LojaServices.Api.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnName("Cliente_Id");

                    b.Property<decimal>("Preco")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnName("Preco")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnName("Produto_Id");

                    b.Property<int>("Quantidade")
                        .HasColumnName("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("LojaServices.Api.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("Bairro")
                        .HasMaxLength(50);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("Cidade")
                        .HasMaxLength(100);

                    b.Property<string>("Complemento")
                        .HasColumnName("Complemento")
                        .HasMaxLength(100);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("Logradouro")
                        .HasMaxLength(200);

                    b.Property<int>("Numero")
                        .HasColumnName("Numero");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("LojaServices.Api.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnName("Categoria")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnName("PrecoUnitario")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("LojaServices.Api.Models.Promocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("DataInicio")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DataTermino")
                        .HasColumnName("DataTermino")
                        .HasMaxLength(100);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("LojaServices.Api.Models.PromocaoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdutoId")
                        .HasColumnName("Produto_Id");

                    b.Property<int>("PromocaoId")
                        .HasColumnName("Promocao_Id");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("PromocaoId");

                    b.ToTable("Promocao_Produto");
                });

            modelBuilder.Entity("LojaServices.Api.Models.Cliente", b =>
                {
                    b.HasOne("LojaServices.Api.Models.Endereco", "EnderecoDeEntrega")
                        .WithOne("Cliente")
                        .HasForeignKey("LojaServices.Api.Models.Cliente", "EnderecoId")
                        .HasConstraintName("FK_Cliente_Endereco")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaServices.Api.Models.Compra", b =>
                {
                    b.HasOne("LojaServices.Api.Models.Cliente", "Cliente")
                        .WithMany("Compras")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_Compra_Cliente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaServices.Api.Models.Produto", "Produtos")
                        .WithMany("Compras")
                        .HasForeignKey("ProdutoId")
                        .HasConstraintName("FK_Compra_Produto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaServices.Api.Models.PromocaoProduto", b =>
                {
                    b.HasOne("LojaServices.Api.Models.Produto", "Produto")
                        .WithMany("Promocoes")
                        .HasForeignKey("ProdutoId")
                        .HasConstraintName("FK__Produto_Promocao");

                    b.HasOne("LojaServices.Api.Models.Promocao", "Promocao")
                        .WithMany("Produtos")
                        .HasForeignKey("PromocaoId")
                        .HasConstraintName("FK__Promocao_Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
