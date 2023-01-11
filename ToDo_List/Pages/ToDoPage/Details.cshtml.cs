using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ToDo ToDo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                ToDo = todo;
            }

            return Page();
        }
    }
}
