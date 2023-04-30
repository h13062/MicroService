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
    public class EmployeeRoleRepositoryAsync : BaseRepositoryAsync<EmployeeRole>, IEmployeeRoleRepositoryAsync
    {
        public EmployeeRoleRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
