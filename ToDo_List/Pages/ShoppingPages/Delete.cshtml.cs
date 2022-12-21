using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ShoppingPages
{
    public class DeleteModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public DeleteModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Shopping Shopping { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shoppings.FirstOrDefaultAsync(m => m.Id == id);

            if (shopping == null)
            {
                return NotFound();
            }
            else 
            {
                Shopping = shopping;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shoppings == null)
            {
                return NotFound();
            }
            var shopping = await _context.Shoppings.FindAsync(id);

            if (shopping != null)
            {
                Shopping = shopping;
                _context.Shoppings.Remove(Shopping);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
