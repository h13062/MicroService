using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Model
{
    public class InterviewerRequestModel
    {
        public int InterviewerID { get; set; }
        
        [Required(ErrorMessage = "First Name is required"), Column(TypeName = "varchar(512)")]
        public string FistName { get; set; }
        [Required(ErrorMessage = "Last Name is required"), Column(TypeName = "varchar(512)")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "EmployeeId is required"), Column(TypeName = "int")]
        public int EmployeeId { get; set; }
    }
}
