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

namespace RecruitCatBechmanaAssignment.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext _context;

        public EditModel(RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company =  await _context.Company.FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }
            Company = company;
           ViewData["IndAssociatedId"] = new SelectList(_context.Set<Industry>(), "IndustryId", "Name");
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

            _context.Attach(Company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.CompanyId))
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

        private bool CompanyExists(int id)
        {
          return (_context.Company?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
