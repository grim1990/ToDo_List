using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ToDos != null)
            {
                ToDo = await _context.ToDos
                .Include(t => t.Category).ToListAsync();
            }
        }
    }
}
