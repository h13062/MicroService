using InterviewCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Service
{
    public interface IInterviewTypeServiceAsync
    {
        Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> DeleteInterviewTypeAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes();
        Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id);

    }
}
