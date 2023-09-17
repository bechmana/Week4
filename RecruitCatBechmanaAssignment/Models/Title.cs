using System.ComponentModel;

namespace RecruitCatBechmanaAssignment.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        [DisplayName("Minimum Salary")]
        public decimal MinSalary { get; set; }
        [DisplayName("Maximum Salary")]
        public decimal MaxSalary { get; set; }
        [DisplayName("Median Salary")]
        public decimal MedianSalary { get; set; }
        public List<Candidate>? Candidates { get; set; }
    }
}
