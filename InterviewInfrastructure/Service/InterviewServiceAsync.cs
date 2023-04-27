using InterviewCore.Entity;
using InterviewCore.Model;
using InterviewCore.Repository;
using InterviewCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewInfrastructure.Service
{
    public class InterviewServiceAsync : IInterviewServiceAsync
    {
        IInterviewRepositoryAsync interviewRepositoryAsync;
        public InterviewServiceAsync(IInterviewRepositoryAsync _interviewRepositoryAsync)
        {
            this.interviewRepositoryAsync = _interviewRepositoryAsync;
        }

        public async Task<int> AddInterviewAsync(InterviewRequestModel model)
        {
            Interview inter = new Interview();
            if (model != null)
            {
                inter.InterviewId = model.InterviewId;
                inter.RecruiterID = model.RecruiterID;
                inter.InterviewTypeCode = model.InterviewTypeCode;
                inter.InterviewRound = model.InterviewRound;
                inter.ScheduleOn = model.ScheduleOn;
                inter.InterviewerId = model.InterviewerId;
                inter.InterviewFeedBackId = model.InterviewFeedBackId;
            }
            return await interviewRepositoryAsync.InsertAsync(inter);

        }

        public async Task<int> DeleteInterviewAsync(int id)
        {
            return await interviewRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviews()
        {
            var collection = await interviewRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<InterviewResponseModel> result = new List<InterviewResponseModel>();
                foreach(var item in collection)
                {
                    InterviewResponseModel model = new InterviewResponseModel();
                    model.InterviewId = item.InterviewId;
                    model.RecruiterID = item.RecruiterID;
                    model.InterviewTypeCode = item.InterviewTypeCode;
                    model.InterviewRound = item.InterviewRound;
                    model.ScheduleOn = item.ScheduleOn;
                    model.InterviewerId = item.InterviewerId;
                    model.InterviewFeedBackId = item.InterviewFeedBackId;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<InterviewResponseModel> GetInterviewByIdAsync(int id)
        {
            var item = await interviewRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                InterviewResponseModel model = new InterviewResponseModel();
                model.InterviewId = item.InterviewId;
                model.RecruiterID = item.RecruiterID;
                model.InterviewTypeCode = item.InterviewTypeCode;
                model.InterviewRound = item.InterviewRound;
                model.ScheduleOn = item.ScheduleOn;
                model.InterviewerId = item.InterviewerId;
                model.InterviewFeedBackId = item.InterviewFeedBackId;
                return model;
            }
            else
            {
                throw new Exception("Cannot find id: " + id);
                return null;
            }
        }

        public async Task<int> UpdateInterviewAsync(InterviewRequestModel model)
        {
            var existingInterview = await interviewRepositoryAsync.GetByIdAsync(model.InterviewId);
            if (existingInterview == null)
            {
                throw new Exception("Interview with id: "+ model.InterviewId + " does not exist");
            }
            Interview inter = new Interview();
            if (model != null)
            {
                inter.InterviewId = model.InterviewId;
                inter.RecruiterID = model.RecruiterID;
                inter.InterviewTypeCode = model.InterviewTypeCode;
                inter.InterviewRound = model.InterviewRound;
                inter.ScheduleOn = model.ScheduleOn;
                inter.InterviewerId = model.InterviewerId;
                inter.InterviewFeedBackId = model.InterviewFeedBackId;
                return await interviewRepositoryAsync.UpdateAsync(inter);
            }
            else
            {
                throw new Exception("Update fail");
                return -1;
            }
        }
    }
}
