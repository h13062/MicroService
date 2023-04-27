using InterviewCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Service
{
    public interface IInterviewerServiceAsync
    {
        Task<int> AddInterviewerAsync(InterviewerRequestModel model);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
        Task<int> DeleteInterviewerAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers();
        Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);

    }
}
