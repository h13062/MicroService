using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewCore.Entity
{
    public class Recruiter
    {
        [Key]
        public int RecruiterId { get; set; }

        [Required]
        [Column(TypeName = "varchar(512)")]
        public string FistName { get; set; }

        [Required]
        [Column(TypeName = "varchar(512)")]
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        public List<Interview>? Interview { get; set; }
    }
}