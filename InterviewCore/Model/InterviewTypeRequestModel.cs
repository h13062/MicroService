using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Model
{
    public class InterviewTypeRequestModel
    {
        public int InterviewTypeCode { get; set; }
        [Required(ErrorMessage = "Description is required"), Column(TypeName = "varchar(512)")]
        public string Description { get; set; }
    }
}
