﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizApplicationMVC.Data;

#nullable disable

namespace QuizApplicationMVC.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241018062222_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizApplicationMVC.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.QuizQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("SelectedOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizQuestion");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.QuizUserHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("QuizUserHistory");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.Questions", b =>
                {
                    b.HasOne("QuizApplicationMVC.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.Quiz", b =>
                {
                    b.HasOne("QuizApplicationMVC.Models.Users", "User")
                        .WithMany("quizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.QuizQuestion", b =>
                {
                    b.HasOne("QuizApplicationMVC.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.QuizUserHistory", b =>
                {
                    b.HasOne("QuizApplicationMVC.Models.Quiz", "Quiz")
                        .WithMany("quizUserHistory")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QuizApplicationMVC.Models.Users", "User")
                        .WithMany("quizUserHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.Quiz", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("quizUserHistory");
                });

            modelBuilder.Entity("QuizApplicationMVC.Models.Users", b =>
                {
                    b.Navigation("quizUserHistory");

                    b.Navigation("quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
