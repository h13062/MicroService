using InterviewCore.Entity;
using InterviewCore.Repository;
using InterviewInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewInfrastructure.Repository
{
    public class InterviewFeedBackRepositoryAsync : BaseRepositoryAsync<InterviewFeedBack>, IInterviewFeedBackRepositoryAsync
    {
        public InterviewFeedBackRepositoryAsync(InterViewDbContext context) : base(context)
        {
        }
    }
}
