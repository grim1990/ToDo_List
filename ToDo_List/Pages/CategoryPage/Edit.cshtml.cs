using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Entieties;
using NLog;
using System.Security.Claims;

namespace ToDo_List.Pages.CategoryPage
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<CategoryPage.EditModel> _logger;

        public EditModel(Data.ApplicationDbContext context, ILogger<CategoryPage.EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            Category = category;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (Category.CreatorGuid!=userId)
            {
                _logger.LogError($"Unauthorized attempt to edit category wiith id= {Category.Id} by user {userId}");
                return RedirectToPage("/Index");
                
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Editing Category id= {Category.Id},incorrectly validated model ");
                return Page();
                

            }

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogTrace($"Edited Category id= {Category.Id} with values name={Category.Name} and description={Category.Description}");

            return RedirectToPage("/Index");
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
