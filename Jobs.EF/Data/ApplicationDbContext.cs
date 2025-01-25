using Jobs.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region DbSets
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionApplication> PositionApplications { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .HasData(
                new Position()
                {
                    ID = 1,
                    Title = "MD Full-Stack Developer",
                    Company = "Coptic Orphans",
                    Location = "Sheraton",
                    Requirement = "2-4 years of related professional experience",
                    Salary = 40000,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!",
                    IsDeleted = false,
                },
                new Position()
                {
                    ID = 2,
                    Title = "SR Full-Stack Developer",
                    Company = "Coptic Orphans",
                    Location = "Sheraton",
                    Requirement = "4-8 years of related professional experience",
                    Salary = 60000,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!",
                    IsDeleted = false,
                },
                new Position()
                {
                    ID = 3,
                    Title = "JR .net Developer",
                    Company = "Company name",
                    Location = "test Location",
                    Requirement = "0-2 years of related professional experience",
                    Salary = 30000,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!",
                    IsDeleted = false,
                },
                new Position()
                {
                    ID = 4,
                    Title = "SR .net Developer",
                    Company = "Company name",
                    Location = "test Location",
                    Requirement = "4-8 years of related professional experience",
                    Salary = 55000,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Beatae accusamus voluptatem error natus earum animi dolores, iure qui repellendus repellat perferendis, molestiae cumque dolore pariatur praesentium illo. Nihil, nostrum odit!",
                    IsDeleted = false,
                });
        }
    }
}
