using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Model
{
    public class InterviewFeedBackRequestModel
    {
        public int InterviewFeedBackId { get; set; }

        [Required(ErrorMessage = "Rating is required"), Column(TypeName = "int")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Rating is required"), Column(TypeName = "varchar(max)")]
        public string Comment { get; set; }
    }
}
