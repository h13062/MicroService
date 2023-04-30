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
    public class EmployeeRepositoryAsync : BaseRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
        public EmployeeRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
