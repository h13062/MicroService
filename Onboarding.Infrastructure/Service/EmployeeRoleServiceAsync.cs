using Onboarding.Core.Contracts.Repository;
using Onboarding.Core.Contracts.Service;
using Onboarding.Core.Entity;
using Onboarding.Core.Exceptions;
using Onboarding.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Infrastructure.Service
{
    public class EmployeeRoleServiceAsync : IEmployeeRoleServiceAsync
    {
        private readonly IEmployeeRoleRepositoryAsync repository;
        public EmployeeRoleServiceAsync(IEmployeeRoleRepositoryAsync repository)
        {
            this.repository = repository;
        }
        public async Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole var = new();
            if (model != null)
            {
                var = new EmployeeRole
                {
                    Name = model.Name,
                    ABBR = model.ABBR,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteEmployeeRoleAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoles()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new EmployeeRoleResponseModel
            {
                LookupCode = x.LookupCode,
                Name = x.Name,
                ABBR = x.ABBR,
            });
        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new EmployeeRoleResponseModel
                {
                    LookupCode = x.LookupCode,
                    Name = x.Name,
                    ABBR = x.ABBR,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.LookupCode);
            if (existing == null)
            {
                throw new Exception("EmployeeRole does not exist");
            }
            if (model != null)
            {
                var var = new EmployeeRole
                {
                    LookupCode = model.LookupCode,
                    Name = model.Name,
                    ABBR = model.ABBR,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
