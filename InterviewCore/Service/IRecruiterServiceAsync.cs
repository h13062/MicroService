using InterviewCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Service
{
    public interface IRecruiterServiceAsync
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters();
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);

    }
}
