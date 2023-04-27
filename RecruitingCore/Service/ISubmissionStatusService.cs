using RecruitingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingCore.Service
{
    public interface ISubmissionStatusService
    {
        Task<int> AddSubmissionAsync(SubmissionStatusRequestModel model);
        Task<int> UpdateSubmissionAsync(SubmissionStatusRequestModel model);
        Task<int> DeleteSubmissionAsync(int id);
        Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissions();
        Task<SubmissionStatusResponseModel> GetSubmissionByIdAsync(int id);
    }
}
