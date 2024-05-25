﻿// <auto-generated />
using System;
using HomewOurK.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240516184958_unique-index-for-group")]
    partial class uniqueindexforgroup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HomewOurK.Domain.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("SubjectGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id", "GroupId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId", "SubjectGroupId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("GroupType")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("UniqGroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("UniqGroupName")
                        .IsUnique();

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.GroupsUsers", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("CompletedHomeworksCount")
                        .HasColumnType("integer");

                    b.Property<int>("CreatedHomeworksCount")
                        .HasColumnType("integer");

                    b.Property<int>("UserExperience")
                        .HasColumnType("integer");

                    b.Property<int>("UserLevel")
                        .HasColumnType("integer");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupsUsers");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Homework", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<int>("Importance")
                        .HasColumnType("integer");

                    b.Property<int?>("SubjectGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id", "GroupId", "SubjectId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId", "SubjectGroupId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Firstname")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("GroupsCount")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateOnly>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<string>("Surname")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectsGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("TeachersId")
                        .HasColumnType("integer");

                    b.Property<int>("TeachersGroupId")
                        .HasColumnType("integer");

                    b.HasKey("SubjectsId", "SubjectsGroupId", "TeachersId", "TeachersGroupId");

                    b.HasIndex("TeachersId", "TeachersGroupId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId", "SubjectGroupId");

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.GroupsUsers", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Group", "Group")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.User", "User")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Homework", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId", "SubjectGroupId");

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Proposal", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Subject", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId", "SubjectsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId", "TeachersGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupsUsers");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.User", b =>
                {
                    b.Navigation("GroupsUsers");
                });
#pragma warning restore 612, 618
        }
    }
}