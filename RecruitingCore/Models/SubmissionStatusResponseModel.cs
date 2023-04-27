using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingCore.Models
{
    public class SubmissionStatusResponseModel
    {
        public int LookupCode { get; set; }

        [MaxLength(int.MaxValue)]
        public string Description { get; set; }
    }
}
