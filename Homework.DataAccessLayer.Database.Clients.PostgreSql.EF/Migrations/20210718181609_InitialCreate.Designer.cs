﻿// <auto-generated />
using Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Homework.DataAccessLayer.Database.Clients.PostgreSql.EF.Migrations
{
    [DbContext(typeof(ClientDbContext))]
    [Migration("20210718181609_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Homework.DataAccessLayer.Database.Mappers.EF.Entities.Task.MapperTaskEntityObject", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_task");

                    b.ToTable("task", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
