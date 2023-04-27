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
    public class InterviewRepositoryAsync : BaseRepositoryAsync<Interview>, IInterviewRepositoryAsync
    {
        public InterviewRepositoryAsync(InterViewDbContext context) : base(context)
        {

        }
    }
}
