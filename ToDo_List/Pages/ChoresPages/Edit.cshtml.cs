using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ChoresPages
{
    public class EditModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public EditModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Chores Chores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chores == null)
            {
                return NotFound();
            }

            var chores =  await _context.Chores.FirstOrDefaultAsync(m => m.Id == id);
            if (chores == null)
            {
                return NotFound();
            }
            Chores = chores;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Chores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoresExists(Chores.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChoresExists(int id)
        {
          return _context.Chores.Any(e => e.Id == id);
        }
    }
}
