using RecruitingCore.Entity;
using RecruitingCore.Repository;
using RecrutingInfrasturcutre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingInfrastructure.Repository
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecrutingDbContext context) : base(context)
        {
        }
    }
}
