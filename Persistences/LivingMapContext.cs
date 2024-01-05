using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Persistences.Models;

namespace Persistences;
public class LivingMapContext : DbContext
{
    public LivingMapContext()
    {

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
    }

    public DbSet<LocationInfo> LocationInfos => Set<LocationInfo>();

    public DbSet<CommonCode> CommonCodes => Set<CommonCode>();

    public DbSet<InterfaceTarget> InterfaceTargets => Set<InterfaceTarget>();
}
