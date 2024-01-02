﻿// <auto-generated />
using System;
using HomewOurK.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomewOurK.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HomewOurK.Domain.Entities.Attachments", b =>
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

            modelBuilder.Entity("HomewOurK.Domain.Entities.Groups", b =>
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

                    b.HasKey("Id");

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

            modelBuilder.Entity("HomewOurK.Domain.Entities.Homeworks", b =>
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

            modelBuilder.Entity("HomewOurK.Domain.Entities.Subjects", b =>
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

            modelBuilder.Entity("HomewOurK.Domain.Entities.Teachers", b =>
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

            modelBuilder.Entity("HomewOurK.Domain.Entities.Users", b =>
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

                    b.HasIndex("Email", "Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SubjectsTeachers", b =>
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

                    b.ToTable("SubjectsTeachers");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Attachments", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Groups", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Subjects", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId", "SubjectGroupId");

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.GroupsUsers", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Groups", "Group")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Users", "User")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Homeworks", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Groups", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Subjects", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId", "SubjectGroupId");

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Subjects", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Groups", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Teachers", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Groups", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("SubjectsTeachers", b =>
                {
                    b.HasOne("HomewOurK.Domain.Entities.Subjects", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId", "SubjectsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomewOurK.Domain.Entities.Teachers", null)
                        .WithMany()
                        .HasForeignKey("TeachersId", "TeachersGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Groups", b =>
                {
                    b.Navigation("GroupsUsers");
                });

            modelBuilder.Entity("HomewOurK.Domain.Entities.Users", b =>
                {
                    b.Navigation("GroupsUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
