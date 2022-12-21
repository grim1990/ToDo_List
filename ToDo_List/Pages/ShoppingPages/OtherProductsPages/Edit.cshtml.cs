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

namespace ToDo_List.Pages.ShoppingPages.OtherProductsPages
{
    public class EditModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public EditModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OtherProducts OtherProducts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OtherProducts == null)
            {
                return NotFound();
            }

            var otherproducts =  await _context.OtherProducts.FirstOrDefaultAsync(m => m.Id == id);
            if (otherproducts == null)
            {
                return NotFound();
            }
            OtherProducts = otherproducts;
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

            _context.Attach(OtherProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherProductsExists(OtherProducts.Id))
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

        private bool OtherProductsExists(int id)
        {
          return _context.OtherProducts.Any(e => e.Id == id);
        }
    }
}
