﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projetoCaixa.Data;

#nullable disable

namespace projetoCaixa.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230520010348_AjusteRelacionamentoVenda")]
    partial class AjusteRelacionamentoVenda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projetoCaixa.Entites.ItemVenda", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<float>("ValorUnitario")
                        .HasColumnType("real");

                    b.Property<int?>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("Id", "IdProduct");

                    b.HasIndex("VendaId");

                    b.ToTable("ItemVendas");
                });

            modelBuilder.Entity("projetoCaixa.Entites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<int?>("ItemVendaId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemVendaIdProduct")
                        .HasColumnType("int");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ItemVendaId", "ItemVendaIdProduct");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("projetoCaixa.Entites.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("projetoCaixa.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("projetoCaixa.Entites.ItemVenda", b =>
                {
                    b.HasOne("projetoCaixa.Entites.Venda", null)
                        .WithMany("ItemVenda")
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("projetoCaixa.Entites.Product", b =>
                {
                    b.HasOne("projetoCaixa.Models.User", "Users")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projetoCaixa.Entites.ItemVenda", null)
                        .WithMany("Products")
                        .HasForeignKey("ItemVendaId", "ItemVendaIdProduct");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("projetoCaixa.Entites.Venda", b =>
                {
                    b.HasOne("projetoCaixa.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("projetoCaixa.Entites.ItemVenda", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("projetoCaixa.Entites.Venda", b =>
                {
                    b.Navigation("ItemVenda");
                });

            modelBuilder.Entity("projetoCaixa.Models.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
