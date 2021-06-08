using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        private const string HerokuConnectionString = "Host=ec2-54-154-101-45.eu-west-1.compute.amazonaws.com;Database=ddtrnl8sda1ba0;Username=kgdqzqeraolyiu;Password=72362679f668c14bce126f2b92e88a41ba157c5cbda719f952051cf00731ab82;sslmode=Require;TrustServerCertificate=true";
        
        public DbSet<CreditInfo> CreditInfos { get; set; }
        public DbSet<Log> Logs { get; set; }
        
        public ApplicationContext()
        {
        }
        
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(HerokuConnectionString);
        }
    }
}