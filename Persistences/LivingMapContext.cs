using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Persistences.Models;
using System.Reflection.Metadata;

namespace Persistences;
public class LivingMapContext : DbContext
{
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InterfaceTarget>()
            .HasOne(e => e.InterfaceTargetConfig)
            .WithOne(e => e.InterfaceTarget)
            .HasForeignKey<InterfaceTargetConfig>(e => e.TargetIdx)
            .IsRequired();

        modelBuilder.Entity<InterfaceTargetConfig>()
            .Property(d => d.ExtractType)
            .HasConversion(new EnumToStringConverter<ExtractType>());
    }

    public DbSet<LocationInfo> LocationInfos => Set<LocationInfo>();

    public DbSet<CommonCode> CommonCodes => Set<CommonCode>();

    public DbSet<InterfaceTarget> InterfaceTargets => Set<InterfaceTarget>();

    public DbSet<InterfaceTargetConfig> InterfaceTargetConfig => Set<InterfaceTargetConfig>();
}
