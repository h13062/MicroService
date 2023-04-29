using Recruiting.Core.Entity;
using Recruiting.Core.Repository;
using Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Repository
{
    public class CandidateRepositoryAsync : BaseRepository<Candidate>, ICandidateRepositoryAsync
    {
        public CandidateRepositoryAsync(RecruitingDbContext context) : base(context)
        {
        }
    }
}
