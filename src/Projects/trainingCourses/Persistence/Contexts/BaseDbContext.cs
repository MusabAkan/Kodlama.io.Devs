using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<CodingSkill> CodingSkills { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions) => Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region CodingSKill
            modelBuilder.Entity<CodingSkill>(coding =>
            {
                coding.ToTable("codingskills").HasKey(i => i.Id);
                coding.Property(p => p.Id).HasColumnName("Id");
                coding.Property(p => p.Name).HasColumnName("Name");
            });

            CodingSkill[] codingSkillSeeds = { new(1, "C#"), new(2, "Java"), new(3, "Python") };
            modelBuilder.Entity<CodingSkill>().HasData(codingSkillSeeds);
            #endregion
        }
    }
}
