﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAAccount.Models1;

namespace WAAccount.Migrations
{
    [DbContext(typeof(demoContext))]
    partial class demoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WAAccount.Models1.Account", b =>
                {
                    b.Property<string>("Account1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AcctType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditOffset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DebitOffset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deparment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Sts")
                        .HasColumnType("bit");

                    b.Property<string>("TypicalBal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Account1");

                    b.ToTable("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
