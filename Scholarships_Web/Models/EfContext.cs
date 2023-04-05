using Microsoft.EntityFrameworkCore;

namespace Scholarships_Web.Models;

public class EfContext : DbContext
{
    public DbSet<Scholarship> Scholarships { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<ScholarshipType> ScholarshipTypes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = @"Server=aws.connect.psdb.cloud;Database=ado_net;user=zk7yao7i5j6d9ihbp3hq;password=pscale_pw_zux2xKx4OAmLoodmJcydJXbPPhjIPapxTr4OUFEgprL;SslMode=VerifyFull;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}