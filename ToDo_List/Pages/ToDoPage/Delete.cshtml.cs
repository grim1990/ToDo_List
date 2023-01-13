using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<ToDoPage.DeleteModel> _logger;

        public DeleteModel(Data.ApplicationDbContext context, ILogger<ToDoPage.DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.LogTrace($"Deleted ToDo with id= {ToDo.Id}");
            }

            return RedirectToPage("/Index");
        }
    }
}
