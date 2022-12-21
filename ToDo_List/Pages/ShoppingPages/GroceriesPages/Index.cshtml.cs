using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ShoppingPages.GroceriesPages
{
    public class IndexModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public IndexModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Groceries> Groceries { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Groceries != null)
            {
                Groceries = await _context.Groceries.ToListAsync();
            }
        }
    }
}
