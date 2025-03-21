﻿// <auto-generated />
using System;
using Event_plus.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event_plus.Migrations
{
    [DbContext(typeof(Evento_Contex))]
    partial class Evento_ContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Event_plus.Domains.ComentarioEvento", b =>
                {
                    b.Property<Guid>("ComentarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EventoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComentarioID");

                    b.HasIndex("EventoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("ComentarioEvento");
                });

            modelBuilder.Entity("Event_plus.Domains.Instituicao", b =>
                {
                    b.Property<Guid>("InstituicaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("CHAR (14)");

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasColumnType("Varchar (50)");

                    b.Property<string>("InstituicaoName")
                        .IsRequired()
                        .HasColumnType("Varchar (40)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("Varchar (50)");

                    b.HasKey("InstituicaoID");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("Event_plus.Domains.TipoEvento", b =>
                {
                    b.Property<Guid>("TipoEventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoEventoName")
                        .IsRequired()
                        .HasColumnType("Varchar (30)");

                    b.HasKey("TipoEventoID");

                    b.ToTable("TipoEvento");
                });

            modelBuilder.Entity("Event_plus.Domains.TipoUsuario", b =>
                {
                    b.Property<Guid>("TipoUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoUsuarioName")
                        .IsRequired()
                        .HasColumnType("Varchar (30)");

                    b.HasKey("TipoUsuarioID");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Eventos", b =>
                {
                    b.Property<Guid>("EventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("InstituicaoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoEventoID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventoID");

                    b.HasIndex("InstituicaoID");

                    b.HasIndex("TipoEventoID");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Presenca", b =>
                {
                    b.Property<Guid>("PresencaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Situcao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PresencaID");

                    b.HasIndex("EventoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Presenca");
                });

            modelBuilder.Entity("api_filmes_senai.Domains.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<Guid?>("TipoUsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TiposUsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UsuarioID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TipoUsuarioID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Event_plus.Domains.ComentarioEvento", b =>
                {
                    b.HasOne("Projeto_Event_Plus.Domains.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoID");

                    b.HasOne("api_filmes_senai.Domains.Usuario", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Eventos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Eventos", b =>
                {
                    b.HasOne("Event_plus.Domains.Instituicao", "Intituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_plus.Domains.TipoEvento", "TipoEvento")
                        .WithMany()
                        .HasForeignKey("TipoEventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intituicao");

                    b.Navigation("TipoEvento");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Presenca", b =>
                {
                    b.HasOne("Projeto_Event_Plus.Domains.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_filmes_senai.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("api_filmes_senai.Domains.Usuario", b =>
                {
                    b.HasOne("Event_plus.Domains.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioID");

                    b.Navigation("TipoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
