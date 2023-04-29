using Recruiting.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Service
{
    public interface ISubmissionStatusServiceAsync
    {
        Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model);
        Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model);
        Task<int> DeleteSubmissionStatusAsync(int id);
        Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatus();
        Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id);
    }
}
