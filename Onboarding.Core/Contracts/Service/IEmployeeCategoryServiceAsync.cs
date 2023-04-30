using Onboarding.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Contracts.Service
{
    public interface IEmployeeCategoryServiceAsync
    {
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> DeleteEmployeeCategoryAsync(int id);
        Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorys();
        Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id);
    }
}
