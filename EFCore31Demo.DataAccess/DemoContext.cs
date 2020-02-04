namespace EFCore31Demo.DataAccess
{
    using EFCore31Demo.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Debug;

    public class DemoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DemoContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DemoContextFactory
    {
        private static readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;";

        public DemoContext Create()
        {
            var builder = new DbContextOptionsBuilder()
                .UseLoggerFactory(DemoLogging.LoggerFactory)
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors(true)
                .UseSqlServer(_connectionString, x => x.UseRelationalNulls(true));

            return new DemoContext(builder.Options);
        }
    }

    internal static class DemoLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });
    }
}
