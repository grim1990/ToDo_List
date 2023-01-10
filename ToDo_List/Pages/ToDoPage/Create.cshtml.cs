﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.ToDoPage
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["CategoryName"] = new SelectList(_context.Categories, "Name", "Name");
            return Page();
        }

        [BindProperty]
        public ToDo ToDo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //_context.Categories.Where(c => c.Name == ToDo.CategoryName);

            _context.ToDos.Add(ToDo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
