using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo_List.Data;
using ToDo_List.Entieties;
using NLog;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace ToDo_List.Pages.CategoryPage
{
    public class CreateModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;
        private readonly ILogger<CategoryPage.CreateModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ToDo_List.Data.ApplicationDbContext context, ILogger<CategoryPage.CreateModel> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            Category.Creator = user;
            Category.CreatorGuid = Guid.Parse(userId);
            var exist = _context.Categories.Any(n => n.Name == Category.Name && n.CreatorGuid==Category.CreatorGuid );
            if (exist||Category.CreatorGuid== new Guid("{00000000-0000-0000-0000-000000000000}"))
            { 
                ModelState.AddModelError("Category.Name", "Kategoria o takiej nazwie już istnieje.");
                _logger.LogError($"Creating Category with wrong name");

            }


            if (!ModelState.IsValid) return Page();
            

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            _logger.LogTrace($"Created new Category id= {Category.Id},with values name= {Category.Name}, description= {Category.Description} by {Category.CreatorGuid}");

            return RedirectToPage("/Index");
        }
    }
}
