using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatBechmanaAssignment.Models
{
    public class Company
    {

        public int CompanyId { get; set; }
        public string Name { get; set; }
        [DisplayName("Position Name")]
        public string PostionName { get; set; }
        [DisplayName("Minimum Salary")]
        public decimal MinSalary { get; set; }
        [DisplayName("Maximum Salary")]
        public decimal MaxSalary { get; set; }
        [DisplayName("Optional Start Date")]
        [DataType(DataType.Date)]
        public DateTime? OptStartDate { get; set; }
        public string Location { get; set; }
        public int? Rating { get; set; }
        public string Description { get; set; }
        [DisplayName("Position Filled")]
        public Boolean PositionFilled { get; set; }
        public List<Candidate>? Candidates { get; set; }
        [DisplayName("Industry")]
        public Industry? IndAssociated { get; set; }
        public int IndAssociatedId { get; set; }
    }
}
