﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vulder.Admin.Infrastructure.Data;

namespace Vulder.Admin.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210831212806_SchoolRequestFormCreate")]
    partial class SchoolRequestFormCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Vulder.Admin.Core.ProjectAggregate.SchoolForm.SchoolForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ApprovedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ApprovedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uuid");

                    b.Property<string>("SchoolName")
                        .HasColumnType("text");

                    b.Property<string>("SchoolUrl")
                        .HasColumnType("text");

                    b.Property<string>("TimetableUrl")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("SchoolForms");
                });

            modelBuilder.Entity("Vulder.Admin.Core.ProjectAggregate.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid[]>("SchoolCollection")
                        .HasColumnType("uuid[]");

                    b.Property<Guid[]>("SchoolFormRequestCollection")
                        .HasColumnType("uuid[]");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
