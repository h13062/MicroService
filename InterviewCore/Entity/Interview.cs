using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Entity
{
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }
        public int RecruiterID { get; set; }
        
        [ForeignKey("RecruiterID")]
        public Recruiter Recruiter { get; set; }
        // public Submission SubmissionId { get; set; }
        public int InterviewTypeCode { get; set; }
        
        [ForeignKey("InterviewTypeCode")]
        public InterviewType InterviewType { get; set; }
        public int InterviewRound { get; set; }
        public DateTime ScheduleOn { get; set; }
        public int InterviewerId { get; set; }

        [ForeignKey("InterviewerId")]
        public Interviewer Interviewer { get; set; }
        public int InterviewFeedBackId { get; set; }
        
        [ForeignKey("InterviewFeedBackId")]
        public InterviewFeedBack InterviewFeedBack { get; set; }

    }
}