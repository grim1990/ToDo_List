using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.WorkPages
{
    public class DetailsModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public DetailsModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Work Work { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Works == null)
            {
                return NotFound();
            }

            var work = await _context.Works.FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }
            else 
            {
                Work = work;
            }
            return Page();
        }
    }
}
