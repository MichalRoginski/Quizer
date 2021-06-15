﻿// <auto-generated />
using System;
using EFCoreDataAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreDataAccessLib.Migrations
{
    [DbContext(typeof(QuizContext))]
    [Migration("20210612141211_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreDataAccess.Models.Question", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Quizid")
                        .HasColumnType("int");

                    b.Property<string>("badAnswer1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("badAnswer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("badAnswer3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("goodAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("Quizid");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("EFCoreDataAccess.Models.Quiz", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("numberOfQuestions")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("quizzes");
                });

            modelBuilder.Entity("EFCoreDataAccess.Models.Question", b =>
                {
                    b.HasOne("EFCoreDataAccess.Models.Quiz", null)
                        .WithMany("questions")
                        .HasForeignKey("Quizid");
                });

            modelBuilder.Entity("EFCoreDataAccess.Models.Quiz", b =>
                {
                    b.Navigation("questions");
                });
#pragma warning restore 612, 618
        }
    }
}
