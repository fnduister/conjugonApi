using ConjugonApi.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ConjugonApi.Core
{
    public class ConjugonDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Verb> Verbs { get; init; }
        public ConjugonDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToCollection("users");
            modelBuilder.Entity<Verb>().ToCollection("verbs");
        }

        public static ConjugonDbContext Create(IMongoDatabase database) => new(new DbContextOptionsBuilder<ConjugonDbContext>()
                                                                            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                                                                            .Options);
    }
}
