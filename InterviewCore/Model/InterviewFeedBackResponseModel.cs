using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Model
{
    public class InterviewFeedBackResponseModel
    {
        public int InterviewFeedBackId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
