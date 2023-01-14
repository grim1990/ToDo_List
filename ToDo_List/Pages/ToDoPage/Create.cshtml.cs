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
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(Data.ApplicationDbContext context, ILogger<ToDoPage.DeleteModel> logger, UserManager<IdentityUser> userManager )
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryName"] = new SelectList(_context.Categories, "Name", "Name");
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            ToDo.Creator = user;
            //ToDo.CreatorGuid = Guid.Parse(userId);
            if (!ModelState.IsValid || ToDo.CreatorGuid== new Guid("{00000000-0000-0000-0000-000000000000}"))
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
