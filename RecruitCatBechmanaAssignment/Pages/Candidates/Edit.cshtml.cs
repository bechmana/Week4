using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatBechmanaAssignment.Data;
using RecruitCatBechmanaAssignment.Models;

namespace RecruitCatBechmanaAssignment.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext _context;

        public EditModel(RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Candidate == null)
            {
                return NotFound();
            }

            var candidate =  await _context.Candidate.FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }
            Candidate = candidate;
           ViewData["CompAssociatedId"] = new SelectList(_context.Set<Company>(), "CompanyId", "Name");
           ViewData["IndAssociatedId"] = new SelectList(_context.Set<Industry>(), "IndustryId", "Name");
           ViewData["TitleAssociatedId"] = new SelectList(_context.Set<Title>(), "TitleId", "Name");
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

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.CandidateId))
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

        private bool CandidateExists(int id)
        {
          return (_context.Candidate?.Any(e => e.CandidateId == id)).GetValueOrDefault();
        }
    }
}
