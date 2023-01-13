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

namespace ToDo_List.Pages.CategoryPage
{
    public class CreateModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;
        private readonly ILogger<CategoryPage.CreateModel> _logger;

        public CreateModel(ToDo_List.Data.ApplicationDbContext context, ILogger<CategoryPage.CreateModel> logger)
        {
            _context = context;
            _logger = logger;
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
            var exist = _context.Categories.Any(n => n.Name == Category.Name);
            if (exist)
            { 
                ModelState.AddModelError("Category.Name", "Kategoria o takiej nazwie już istnieje.");
                _logger.LogError($"Creating Category with wrong name");

            }


            if (!ModelState.IsValid) return Page();
            

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            _logger.LogTrace($"Created new Category id= {Category.Id},with values name= {Category.Name}, description= {Category.Description}");

            return RedirectToPage("/Index");
        }
    }
}
