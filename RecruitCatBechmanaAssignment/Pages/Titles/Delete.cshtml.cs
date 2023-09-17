using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatBechmanaAssignment.Data;
using RecruitCatBechmanaAssignment.Models;

namespace RecruitCatBechmanaAssignment.Pages.Titles
{
    public class DeleteModel : PageModel
    {
        private readonly RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext _context;

        public DeleteModel(RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Title Title { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Title == null)
            {
                return NotFound();
            }

            var title = await _context.Title.FirstOrDefaultAsync(m => m.TitleId == id);

            if (title == null)
            {
                return NotFound();
            }
            else 
            {
                Title = title;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Title == null)
            {
                return NotFound();
            }
            var title = await _context.Title.FindAsync(id);

            if (title != null)
            {
                Title = title;
                _context.Title.Remove(Title);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
