using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;
using static ToDo_List.Entieties.User;

namespace ToDo_List.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Category>()
        //                .HasMany(c => c.ToDos)
        //                .WithOne(t => t.Category);
        //    //                //.HasForeignKey(t => t.CategoryId);
        //}

    }
}