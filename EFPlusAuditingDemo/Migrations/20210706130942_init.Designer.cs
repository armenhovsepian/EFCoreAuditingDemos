﻿// <auto-generated />
using System;
using EFPlusAuditingDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFPlusAuditingDemo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210706130942_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EFPlusAuditingDemo.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Property<int>("AuditEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EntitySetName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("EntityTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("StateName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("AuditEntryID");

                    b.ToTable("AuditEntries");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.Property<int>("AuditEntryPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AuditEntryID")
                        .HasColumnType("integer");

                    b.Property<string>("NewValueFormatted")
                        .HasColumnType("text")
                        .HasColumnName("NewValue");

                    b.Property<string>("OldValueFormatted")
                        .HasColumnType("text")
                        .HasColumnName("OldValue");

                    b.Property<string>("PropertyName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("RelationName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("AuditEntryPropertyID");

                    b.HasIndex("AuditEntryID");

                    b.ToTable("AuditEntryProperties");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.HasOne("Z.EntityFramework.Plus.AuditEntry", "Parent")
                        .WithMany("Properties")
                        .HasForeignKey("AuditEntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}