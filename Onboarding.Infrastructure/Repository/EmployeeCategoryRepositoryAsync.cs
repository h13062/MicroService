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
    public class EmployeeCategoryRepositoryAsync : BaseRepositoryAsync<EmployeeCategory>, IEmployeeCategoryRepositoryAsync
    {
        public EmployeeCategoryRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
