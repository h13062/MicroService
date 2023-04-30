using Onboarding.Core.Contracts.Repository;
using Onboarding.Core.Entity;
using Onboarding.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Infrastructure.Repository
{
    public class EmployeeStatusRepositoryAsync : BaseRepositoryAsync<EmployeeStatus>, IEmployeeStatusRepositoryAsync
    {
        public EmployeeStatusRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
