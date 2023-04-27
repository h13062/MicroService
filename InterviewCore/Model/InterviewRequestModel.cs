using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Model
{
    public class InterviewRequestModel
    {
        public int InterviewId { get; set; }
        public int RecruiterID { get; set; }
        public int InterviewTypeCode { get; set; }
        public int InterviewRound { get; set; }
        public DateTime ScheduleOn { get; set; }
        public int InterviewerId { get; set; }
        public int InterviewFeedBackId { get; set; }

    }
}
