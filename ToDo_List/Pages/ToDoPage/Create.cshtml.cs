﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<ToDoPage.DeleteModel> _logger;
     

        public CreateModel(Data.ApplicationDbContext context, ILogger<ToDoPage.DeleteModel> logger )
        {
            _context = context;
            _logger = logger;
     
        }

        public IActionResult OnGet()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewData["CategoryName"] = new SelectList(_context.Categories.Where(u=>u.CreatorGuid==userId), "Name", "Name");
            return Page();
        }

        [BindProperty]
        public ToDo ToDo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var category = _context.Categories.First(c => c.Name == ToDo.CategoryName);
            var catId = _context.Categories.Select(i => i.Id).ToList();
            ToDo.Category = category;
            ToDo.CategoryId = category.Id;

            if (!ModelState.IsValid )
            {
                _logger.LogError($"Creating ToDo with wrong data");
                return RedirectToPage();
                
            }

            _context.ToDos.Add(ToDo);
            await _context.SaveChangesAsync();
            _logger.LogTrace($"Created new ToDo id= {ToDo.Id},with values name= {ToDo.Name}, priority= {ToDo.Priority} and category name= {ToDo.CategoryName}");

            return RedirectToPage("/Index");
        }
    }
}
