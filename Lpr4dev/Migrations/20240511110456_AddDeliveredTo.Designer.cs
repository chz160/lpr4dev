﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Lpr4dev.Data;

#nullable disable

namespace Lpr4dev.Migrations
{
    [DbContext(typeof(Lpr4devDbContext))]
    [Migration("20240511110456_AddDeliveredTo")]
    partial class AddDeliveredTo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

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

            modelBuilder.Entity("Lpr4dev.DbModel.Mailbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mailboxes");
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

                    b.Property<string>("DeliveredTo")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("EightBitTransport")
                        .HasColumnType("INTEGER");

                    b.Property<string>("From")
                        .HasColumnType("TEXT");

                    b.Property<long>("ImapUid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUnread")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("MailboxId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeParseError")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RelayError")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SecureConnection")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionEncoding")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SessionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MailboxId");

                    b.HasIndex("SessionId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Lpr4dev.DbModel.MessageRelay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("To")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageRelays");
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
                    b.HasOne("Lpr4dev.DbModel.Mailbox", "Mailbox")
                        .WithMany()
                        .HasForeignKey("MailboxId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lpr4dev.DbModel.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");

                    b.Navigation("Mailbox");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Lpr4dev.DbModel.MessageRelay", b =>
                {
                    b.HasOne("Lpr4dev.DbModel.Message", "Message")
                        .WithMany("Relays")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Lpr4dev.DbModel.Message", b =>
                {
                    b.Navigation("Relays");
                });
#pragma warning restore 612, 618
        }
    }
}
