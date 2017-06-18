using System.Data.Entity;

namespace MuseumProject.Context
{
    public class MuseumContext : DbContext
    {
        public MuseumContext() : base("AzureConnection") { }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<InformationType> InformationType { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Counter> Counters { get; set; }
    }
}