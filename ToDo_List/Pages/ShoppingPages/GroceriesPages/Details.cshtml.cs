﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly ToDo_List.Data.ApplicationDbContext _context;

        public DetailsModel(ToDo_List.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Groceries Groceries { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groceries == null)
            {
                return NotFound();
            }

            var groceries = await _context.Groceries.FirstOrDefaultAsync(m => m.Id == id);
            if (groceries == null)
            {
                return NotFound();
            }
            else 
            {
                Groceries = groceries;
            }
            return Page();
        }
    }
}
