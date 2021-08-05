﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vulder.Admin.Infrastructure.Data;

namespace Vulder.Admin.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Vulder.Admin.Core.ProjectAggregate.School.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("SchoolBaseUrl")
                        .HasColumnType("text");

                    b.Property<string>("SchoolTimetableUrl")
                        .HasColumnType("text");

                    b.Property<Guid?>("User")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("User");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Vulder.Admin.Core.ProjectAggregate.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<Guid[]>("SchoolCollection")
                        .HasColumnType("uuid[]");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vulder.Admin.Core.ProjectAggregate.School.School", b =>
                {
                    b.HasOne("Vulder.Admin.Core.ProjectAggregate.User.User", "Guardian")
                        .WithMany()
                        .HasForeignKey("User");

                    b.Navigation("Guardian");
                });
#pragma warning restore 612, 618
        }
    }
}
