using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingCore.Models
{
    public class CandidateRequestModel
    {
        public int Id { get; set; }
        [MaxLength(50)]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }

        public string ResumeURL { get; set; }
    }
}
