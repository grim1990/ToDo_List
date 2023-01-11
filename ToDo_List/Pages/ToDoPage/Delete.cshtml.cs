using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DeleteModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDo ToDo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo = await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo = await _context.ToDos.FindAsync(id);

            if (todo != null)
            {
                ToDo = todo;
                _context.ToDos.Remove(ToDo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
