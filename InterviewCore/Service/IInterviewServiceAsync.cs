using InterviewCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Service
{
    public interface IInterviewServiceAsync
    {
        Task<int> AddInterviewAsync(InterviewRequestModel model);
        Task<int> UpdateInterviewAsync(InterviewRequestModel model);
        Task<int> DeleteInterviewAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<InterviewResponseModel>> GetAllInterviews();
        Task<InterviewResponseModel> GetInterviewByIdAsync(int id);
    }
}
