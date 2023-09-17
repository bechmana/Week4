using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatBechmanaAssignment.Data;
using RecruitCatBechmanaAssignment.Models;

namespace RecruitCatBechmanaAssignment.Pages.Candidates
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext _context;

        public DetailsModel(RecruitCatBechmanaAssignment.Data.RecruitCatBechmanaAssignmentContext context)
        {
            _context = context;
        }

      public Candidate Candidate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Candidate == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate.FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }
            else 
            {
                Candidate = candidate;
            }
            return Page();
        }
    }
}
