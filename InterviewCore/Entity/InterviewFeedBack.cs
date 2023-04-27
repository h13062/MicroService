using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewCore.Entity
{
    public class InterviewFeedBack
    {
        [Key]
        public int InterviewFeedBackId { get; set; }
        [Required]
        public int Rating { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Comment { get; set; }
        public List<Interview>? Interview { get; set; }

    }
}