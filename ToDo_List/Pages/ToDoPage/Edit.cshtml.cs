using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<ToDoPage.DeleteModel> _logger;

        public EditModel(Data.ApplicationDbContext context, ILogger<ToDoPage.DeleteModel> logger)
        {
            _context = context;
            _logger = logger;   
        }

        [BindProperty]
        public ToDo ToDo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var todo =  await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            ToDo = todo;
            ViewData["CategoryName"] = new SelectList(_context.Categories, "Name", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //ModelState.Clear();

            var category = _context.Categories.First(c => c.Name == ToDo.CategoryName);
            var catId = _context.Categories.Select(i => i.Id).ToList();
            ToDo.Category = category;
            ToDo.CategoryId = category.Id;

            if (!ModelState.IsValid)
            {
                return RedirectToPage();
                _logger.LogError($"Editing ToDo with wrong data");

            }

            _context.Attach(ToDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(ToDo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogTrace($"Edited ToDo id= {ToDo.Id} with values name={ToDo.Name}, priority={ToDo.Priority} and category name= {ToDo.CategoryName}");


            return RedirectToPage("/Index");
        }

        private bool ToDoExists(int id)
        {
          return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
