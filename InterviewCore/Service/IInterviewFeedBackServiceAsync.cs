using InterviewCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCore.Service
{
    public interface IInterviewFeedBackServiceAsync
    {
        Task<int> AddInterviewFeedBackAsync(InterviewFeedBackRequestModel model);
        Task<int> UpdateInterviewFeedBackAsync(InterviewFeedBackRequestModel model);
        Task<int> DeleteInterviewFeedBackAsync(int id);
        Task<IEnumerable<InterviewFeedBackResponseModel>> GetAllInterviewFeedBacks();
        Task<InterviewFeedBackResponseModel> GetInterviewFeedBackByIdAsync(int id);

    }
}
