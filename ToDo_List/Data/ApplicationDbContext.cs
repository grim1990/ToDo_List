using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Chores> Chores { get; set; }
		public DbSet<Products> Products { get; set; }
		public DbSet<Shopping> Shoppings { get; set; }
		public DbSet<ToDo> ToDos { get; set; }
		public DbSet<Work> Works { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}