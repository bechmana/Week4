using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatBechmanaAssignment.Data;
using RecruitCatBechmanaAssignment.Models;

namespace RecruitCatBechmanaAssignment.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext _context;

        public CreateModel(RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompAssociatedId"] = new SelectList(_context.Set<Company>(), "CompanyId", "Name");
        ViewData["IndAssociatedId"] = new SelectList(_context.Set<Industry>(), "IndustryId", "Name");
        ViewData["TitleAssociatedId"] = new SelectList(_context.Set<Title>(), "TitleId", "Name");
            return Page();
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Candidate == null || Candidate == null)
            {
                return Page();
            }

            _context.Candidate.Add(Candidate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
