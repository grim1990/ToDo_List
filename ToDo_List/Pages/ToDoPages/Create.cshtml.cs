using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPages
{
    public class CreateModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public CreateModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDo ToDo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.ToDos.Add(ToDo);
            
            await _context.SaveChangesAsync();
            var option = Request.Form["option"];

            if (option == "Chores")
            {
                return RedirectToPage("/ChoresPages/Create", "OnPostAsync", new { toDoId = ToDo.Id });
            }
            else if (option == "Work")
            {
                return RedirectToPage("/WorkPages/Create", "OnPostAsync", new { toDoId = ToDo.Id });
            }
            else 
            {
                return RedirectToPage("/ShoppingPages/Create", "OnPostAsync", new { toDoId = ToDo.Id });
            }
        }
        
    }
}
