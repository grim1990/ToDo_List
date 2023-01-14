using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Security.Claims;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.CategoryPage
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<CategoryPage.DeleteModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(Data.ApplicationDbContext context, ILogger<CategoryPage.DeleteModel> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        [BindProperty]
        public Category Category { get; set; }

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
            else
            {
                Category = category;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); 
            if (id == null || _context.Categories == null)
            {
                return NotFound();
                _logger.LogError($"Category id= {id} not found");

            }
            var category = await _context.Categories.FindAsync(id);
            if (category.CreatorGuid!=userId)
            {
                return NotFound();
                _logger.LogError($"Unauthorized attempt to remove category id= {category.Id} by user {userId}");
            }

            if (category != null)
            {
                Category = category;
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
                _logger.LogTrace($"Deleted Category id= {id}");

            }

            return RedirectToPage("/Index");
        }
    }
}
