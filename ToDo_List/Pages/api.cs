using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages
{
	[Route("[controller]")]
	public class ApiController : Controller
	{
		private readonly Data.ApplicationDbContext _db;

		public ApiController(Data.ApplicationDbContext db)
		{
			_db = db;
		}

		public IList<ToDo> Todos { get; set; }
		

		[HttpPost("{id}")]
		public void Post(int id)
		{
			var todo = _db.ToDos.Find(id);
			todo.IsCompleted = !todo.IsCompleted;
			_db.SaveChanges();

		}
	}
}	