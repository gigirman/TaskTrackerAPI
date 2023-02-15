﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskTrackerAPI;

#nullable disable

namespace TaskTrackerAPI.Migrations
{
    [DbContext(typeof(TaskTrackerContext))]
    [Migration("20230208194839_3rdMigrationNullableAfterSafe")]
    partial class _3rdMigrationNullableAfterSafe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TaskTrackerAPI.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CompletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrentStatusId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TaskTrackerAPI.Models.ProjectStatusLookup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatusLookup");
                });

            modelBuilder.Entity("TaskTrackerAPI.Models.Tasks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CurrentTaskStatusId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Priority")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CurrentTaskStatusId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskTrackerAPI.Models.TaskStatusLookup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TaskStatusLookup");
                });

            modelBuilder.Entity("TaskTrackerAPI.Models.Project", b =>
                {
                    b.HasOne("TaskTrackerAPI.Models.ProjectStatusLookup", "CurrentStatus")
                        .WithMany()
                        .HasForeignKey("CurrentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentStatus");
                });

            modelBuilder.Entity("TaskTrackerAPI.Models.Tasks", b =>
                {
                    b.HasOne("TaskTrackerAPI.Models.TaskStatusLookup", "CurrentTaskStatus")
                        .WithMany()
                        .HasForeignKey("CurrentTaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskTrackerAPI.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.Navigation("CurrentTaskStatus");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TaskTrackerAPI.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
