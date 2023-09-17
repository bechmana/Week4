using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitCatBechmanaAssignment.Models;

namespace RecruitCatBechmanaAssignment.Data
{
    public class RecruitCatBechmanaAssignmentContext : DbContext
    {
        public RecruitCatBechmanaAssignmentContext (DbContextOptions<RecruitCatBechmanaAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<RecruitCatBechmanaAssignment.Models.Candidate> Candidate { get; set; } = default!;

        public DbSet<RecruitCatBechmanaAssignment.Models.Company>? Company { get; set; }

        public DbSet<RecruitCatBechmanaAssignment.Models.Industry>? Industry { get; set; }

        public DbSet<RecruitCatBechmanaAssignment.Models.Title>? Title { get; set; }
    }
}
