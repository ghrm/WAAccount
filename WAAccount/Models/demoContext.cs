using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WAAccount.Models1
{
    public partial class demoContext : DbContext
    {
        public demoContext()
        {
        }

        public demoContext(DbContextOptions<demoContext> options) : base(options)
        {
        }

        public virtual DbSet<AccountT> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=demo;User Id= sa; Password=bacabsa;");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        //    modelBuilder.Entity<Account>(entity =>
        //    {
        //        entity.HasKey(e => e.Account1);

        //        entity.Property(e => e.Account1)
        //            .HasMaxLength(10)
        //            .HasColumnName("Account");
        //            //.IsFixedLength(true);

        //        entity.Property(e => e.AcctType)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.CreditOffset)
        //            .IsRequired()
        //            .HasMaxLength(10);
        //        //.IsFixedLength(true);

        //        entity.Property(e => e.DebitOffset)
        //            .IsRequired()
        //            .HasMaxLength(10)
        //            .HasDefaultValueSql("((0))");
        //            //.IsFixedLength(true);

        //        entity.Property(e => e.Deparment)
        //            .IsRequired()
        //            .HasMaxLength(250);

        //        entity.Property(e => e.Description)
        //            .IsRequired()
        //            .HasMaxLength(250);

        //        entity.Property(e => e.Sts)
        //            .IsRequired()
        //            .HasColumnName("sts")
        //            .HasDefaultValueSql("((1))");

        //        entity.Property(e => e.TypicalBal)
        //            .HasMaxLength(2);
        //            //.IsFixedLength(true);
        //    });
        //    Console.WriteLine("ok");
        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
