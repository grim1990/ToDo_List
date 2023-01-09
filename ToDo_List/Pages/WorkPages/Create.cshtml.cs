using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo_List.Data;
using ToDo_List.Entieties;

namespace ToDo_List.Pages.WorkPages
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
            if (ToDo.WorkId != null||ToDo.ChoresId!=null||ToDo.ShoppingId!=null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public Work Work { get; set; }
        public ToDo ToDo { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int toDoId)
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            Work.ToDoId = toDoId;

            _context.Works.Add(Work);
            await _context.SaveChangesAsync();
            var todo = await _context.ToDos.FindAsync(toDoId);
            todo.WorkId = Work.Id;
            await _context.SaveChangesAsync();  

            return RedirectToPage("/ToDoPages/Create");
        }
    }
}
