using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ShoppingPages
{
    public class CreateModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public CreateModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int toDoId)
        {
            var ToDo = _context.ToDos.Find(toDoId);
            if (ToDo == null)
            {
                return NotFound();
            }
            if (ToDo.WorkId != null || ToDo.ChoresId != null || ToDo.ShoppingId != null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Shopping Shopping { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int toDoId)
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            Shopping.ToDoId = toDoId;
            _context.Shoppings.Add(Shopping);
            await _context.SaveChangesAsync();
            var todo = await _context.ToDos.FindAsync(toDoId);
            todo.ShoppingId = Shopping.Id;
            await _context.SaveChangesAsync();

            return RedirectToPage("./ProductsPages/Create", new { shoppingId = Shopping.Id });
        }
    }
}
