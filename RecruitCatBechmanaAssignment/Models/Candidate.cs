using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatBechmanaAssignment.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        [DisplayName("First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [DisplayName("Target Salary")]
        public decimal? TargetSalary { get; set; }
        [DisplayName("Optional Start Date")]
        [DataType(DataType.Date)]
        public DateTime? OptionalStartDate { get; set; }
        public Boolean Hired { get; set; }
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Company")]
        public Company? CompAssociated { get; set; }
        public int CompAssociatedId { get; set; }
        [DisplayName("Title")]
        public Title? TitleAssociated { get; set; }
        public int TitleAssociatedId { get; set; }
        [DisplayName("Industry")]
        public Industry? IndAssociated { get; set; }
        public int IndAssociatedId { get; set; }

    }
}
