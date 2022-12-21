using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ChoresPages
{
    public class DeleteModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public DeleteModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Chores Chores { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chores == null)
            {
                return NotFound();
            }

            var chores = await _context.Chores.FirstOrDefaultAsync(m => m.Id == id);

            if (chores == null)
            {
                return NotFound();
            }
            else 
            {
                Chores = chores;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Chores == null)
            {
                return NotFound();
            }
            var chores = await _context.Chores.FindAsync(id);

            if (chores != null)
            {
                Chores = chores;
                _context.Chores.Remove(Chores);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
