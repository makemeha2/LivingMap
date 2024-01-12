using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Persistences.Models;
using System.Reflection.Metadata;

namespace Persistences;
public partial class LivingMapContext : DbContext
{
    //public LivingMapContext(DbContextOptions<LivingMapContext>? options = null) : base(options)
    public LivingMapContext()
    {
        //Database.Log = sql => Debug.Write(sql);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(@"Server=.\;Database=LivingMapDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        var connectionString = string.Empty;
        using (StreamReader r = new StreamReader(@"C:\01_VS_WorkSpace\LivingMap\secrets.key"))
        { 
            connectionString = r.ReadToEnd();
        }

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(Console.WriteLine);
    }

    public virtual DbSet<AddrExtrInfo> AddrExtrInfos { get; set; }

    public virtual DbSet<AdmCode> AdmCodes { get; set; }

    public virtual DbSet<CommonCode> CommonCodes { get; set; }

    public virtual DbSet<ExtractAddress> ExtractAddresses { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddrExtrInfo>(entity =>
        {
            entity.HasKey(e => new { e.Div, e.Area1Code, e.Area2Code });

            entity.ToTable("AddrExtrInfo");

            entity.Property(e => e.Div)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Area1Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Area2Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ExtractType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.FilePath).HasMaxLength(300);
            entity.Property(e => e.Ifdate).HasColumnName("IFDate");
            entity.Property(e => e.IfsuccessYn).HasColumnName("IFSuccessYN");
            entity.Property(e => e.ReflectionClsName)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AdmCode).WithMany(p => p.AddrExtrInfos)
                .HasForeignKey(d => new { d.Area1Code, d.Area2Code })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddrExtrInfo_AdmCode");
        });

        modelBuilder.Entity<AdmCode>(entity =>
        {
            entity.HasKey(e => new { e.Area1Code, e.Area2Code });

            entity.ToTable("AdmCode");

            entity.Property(e => e.Area1Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Area2Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Area1Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Area2Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CommonCode>(entity =>
        {
            entity.HasKey(e => new { e.CodeGroup, e.Code });

            entity.ToTable("CommonCode");
        });

        modelBuilder.Entity<ExtractAddress>(entity =>
        {
            entity.HasKey(e => new { e.Div, e.AddressText });

            entity.ToTable("ExtractAddress");

            entity.Property(e => e.Div)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddressText).HasMaxLength(300);
            entity.Property(e => e.Area1Code)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Area2Code)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.AddrExtrInfo).WithMany(p => p.ExtractAddresses)
                .HasForeignKey(d => new { d.Div, d.Area1Code, d.Area2Code })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExtractAddress_AddrExtrInfo");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => new { e.Div, e.AddressText });

            entity.ToTable("Location");

            entity.Property(e => e.Div)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddressText).HasMaxLength(300);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(120);
            entity.Property(e => e.Level0).HasMaxLength(100);
            entity.Property(e => e.Level1).HasMaxLength(100);
            entity.Property(e => e.Level2).HasMaxLength(100);
            entity.Property(e => e.Level3).HasMaxLength(100);
            entity.Property(e => e.Level4A).HasMaxLength(100);
            entity.Property(e => e.Level4L).HasMaxLength(100);
            entity.Property(e => e.Level4Lc)
                .HasMaxLength(100)
                .HasColumnName("Level4LC");
            entity.Property(e => e.Level5).HasMaxLength(100);
            entity.Property(e => e.MetaAddress).HasMaxLength(500);
            entity.Property(e => e.SuccessYn).HasColumnName("SuccessYN");
            entity.Property(e => e.UseYn).HasColumnName("UseYN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
