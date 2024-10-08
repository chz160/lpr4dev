﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Lpr4dev.Data;

namespace Lpr4dev.Migrations
{
    [DbContext(typeof(Lpr4devDbContext))]
    [Migration("20210731045851_UTCTimeMigration")]
    partial class UTCTimeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Lpr4dev.DbModel.ImapState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("LastUid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ImapState");
                });

            modelBuilder.Entity("Lpr4dev.DbModel.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AttachmentCount")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .HasColumnType("BLOB");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<long>("ImapUid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUnread")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MimeParseError")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RelayError")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SecureConnection")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("SessionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Lpr4dev.DbModel.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Log")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfMessages")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionError")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SessionErrorType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Lpr4dev.DbModel.Message", b =>
                {
                    b.HasOne("Lpr4dev.DbModel.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");

                    b.Navigation("Session");
                });
#pragma warning restore 612, 618
        }
    }
}
