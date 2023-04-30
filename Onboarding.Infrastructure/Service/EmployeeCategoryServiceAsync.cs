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
    public class EmployeeCategoryServiceAsync : IEmployeeCategoryServiceAsync
    {
        private readonly IEmployeeCategoryRepositoryAsync repository;

        public EmployeeCategoryServiceAsync(IEmployeeCategoryRepositoryAsync repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            EmployeeCategory var = new();
            if (model != null)
            {
                var = new EmployeeCategory
                {
                    Description = model.Description,
                };
            }
            return await repository.InsertAsync(var);
        }

        public async Task<int> DeleteEmployeeCategoryAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorys()
        {
            var var = await repository.GetAllAsync();
            return var.Select(x => new EmployeeCategoryResponseModel
            {
                LookupCode = x.LookupCode,
                Description = x.Description,
            });
        }

        public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id)
        {
            var x = await repository.GetByIdAsync(id);
            if (x != null)
            {
                return new EmployeeCategoryResponseModel
                {
                    LookupCode = x.LookupCode,
                    Description = x.Description,
                };
            }
            throw new NotFoundException();
        }

        public async Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            var existing = await repository.GetByIdAsync(model.LookupCode);
            if (existing == null)
            {
                throw new Exception("EmployeeCategory does not exist");
            }
            if (model != null)
            {
                var var = new EmployeeCategory
                {
                    LookupCode = model.LookupCode,
                    Description = model.Description,
                };
                return await repository.UpdateAsync(var);
            }
            return -1;
        }
    }
}
