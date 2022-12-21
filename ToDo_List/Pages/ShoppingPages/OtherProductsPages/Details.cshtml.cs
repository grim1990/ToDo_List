using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ShoppingPages.OtherProductsPages
{
    public class DetailsModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public DetailsModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public OtherProducts OtherProducts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OtherProducts == null)
            {
                return NotFound();
            }

            var otherproducts = await _context.OtherProducts.FirstOrDefaultAsync(m => m.Id == id);
            if (otherproducts == null)
            {
                return NotFound();
            }
            else 
            {
                OtherProducts = otherproducts;
            }
            return Page();
        }
    }
}
