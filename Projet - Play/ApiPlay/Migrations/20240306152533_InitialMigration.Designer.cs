﻿// <auto-generated />
using System;
using ApiPlay.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPlay.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240306152533_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiPlay.Models.Jeux", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CheminJaquette")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jeuxs");
                });

            modelBuilder.Entity("ApiPlay.Models.Joueur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CheminAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Joueurs");
                });

            modelBuilder.Entity("ApiPlay.Models.JoueurJeux", b =>
                {
                    b.Property<int>("JoueurId")
                        .HasColumnType("int");

                    b.Property<int>("JeuxId")
                        .HasColumnType("int");

                    b.HasKey("JoueurId", "JeuxId");

                    b.HasIndex("JeuxId");

                    b.ToTable("JoueurJeuxs");
                });

            modelBuilder.Entity("ApiPlay.Models.JoueurJeux", b =>
                {
                    b.HasOne("ApiPlay.Models.Jeux", "Jeux")
                        .WithMany("JoueurJeuxs")
                        .HasForeignKey("JeuxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPlay.Models.Joueur", "Joueur")
                        .WithMany("JoueurJeuxs")
                        .HasForeignKey("JoueurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jeux");

                    b.Navigation("Joueur");
                });

            modelBuilder.Entity("ApiPlay.Models.Jeux", b =>
                {
                    b.Navigation("JoueurJeuxs");
                });

            modelBuilder.Entity("ApiPlay.Models.Joueur", b =>
                {
                    b.Navigation("JoueurJeuxs");
                });
#pragma warning restore 612, 618
        }
    }
}
