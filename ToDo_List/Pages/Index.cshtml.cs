using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages
{
	public class IndexModel : PageModel
	{
		private readonly Data.ApplicationDbContext _db;

		public IndexModel(Data.ApplicationDbContext db)
		{
			_db = db;
		}

		public IList<Category> Categories { get; set; }
		public IList<ToDo> Todos { get; set; }
		public Category Category { get; set; }
		public async Task OnGet(int? id)
		{
			// Get selected category
			var category = await _db.Categories.FirstOrDefaultAsync(m => m.Id == id);

			// If there is no category id in query params or id is invalid get first Category
			if (category == null)
			{
				Category = await _db.Categories.FirstOrDefaultAsync();
			}
			else
			{
				Category = category;
			}

			// set id to current category
			id = Category.Id;

			if (_db.Categories != null)
			{
				Categories = _db.Categories.ToList();
				Todos = _db.ToDos.Where(x => x.CategoryId == id).ToList();
			}
		}
	}
}