using RecruitingCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingCore.Models
{
    public class SubmissionRequestModel
    {
        public int SubmissionId { get; set; }
        public JobRequirement? JobRequirementId { get; set; }  //        FK, UNIQUE with CandidateId
        public Candidate? CandidateId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }
        public SubmissionStatus? Status { get; set; } //SubmissionStatusCode FK

    }
}
