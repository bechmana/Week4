namespace RecruitCatBechmanaAssignment.Models
{
    public class Industry
    {
        public int IndustryId { get; set; }
        public string Name { get; set; }
        public List<Candidate>? Candidates { get; set; }
        public List<Company>? Companies { get; set; }
    }
}
