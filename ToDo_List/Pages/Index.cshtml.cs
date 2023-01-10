using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ToDo_List.Data.ApplicationDbContext _db;

		public IndexModel(ToDo_List.Data.ApplicationDbContext db)
		{
			_db = db;
		}

		public IList<Category> Categories { get; set; }

		public async Task OnGet()
		{
			if (_db.Categories != null)
			{
				Categories = _db.Categories.ToList();
			}
		}

	}
}