using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewCore.Entity
{
    public class InterviewType
    {
        [Key]
        public int InterviewTypeCode { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(512)")]
        public string Description { get; set; }
        public List<Interview>? Interview { get; set; }
    }
}