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
    public class InterviewFeedBackServiceAsync : IInterviewFeedBackServiceAsync
    {
        IInterviewFeedBackRepositoryAsync interviewFeedBackRepositoryAsync;
        public InterviewFeedBackServiceAsync(IInterviewFeedBackRepositoryAsync _interviewFeedBackRepositoryAsync)
        {
            this.interviewFeedBackRepositoryAsync = _interviewFeedBackRepositoryAsync;
        }

        public async Task<int> AddInterviewFeedBackAsync(InterviewFeedBackRequestModel model)
        {
            InterviewFeedBack inter = new InterviewFeedBack();
            if (model != null)
            {
               inter.InterviewFeedBackId = model.InterviewFeedBackId;
               inter.Rating = model.Rating;
               inter.Comment = model.Comment;
            }
            return await interviewFeedBackRepositoryAsync.InsertAsync(inter);
        }

        public async Task<int> DeleteInterviewFeedBackAsync(int id)
        {
            return await interviewFeedBackRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewFeedBackResponseModel>> GetAllInterviewFeedBacks()
        {
            var collection = await interviewFeedBackRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<InterviewFeedBackResponseModel> result = new List<InterviewFeedBackResponseModel>();
                foreach (var item in collection)
                {
                    InterviewFeedBackResponseModel model = new InterviewFeedBackResponseModel();
                    model.InterviewFeedBackId = item.InterviewFeedBackId;
                    model.Rating = item.Rating; 
                    model.Comment = item.Comment;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<InterviewFeedBackResponseModel> GetInterviewFeedBackByIdAsync(int id)
        {
            var item = await interviewFeedBackRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                InterviewFeedBackResponseModel model = new InterviewFeedBackResponseModel();
                model.InterviewFeedBackId = item.InterviewFeedBackId;
                model.Rating = item.Rating;
                model.Comment = item.Comment;
                return model;
            }
            else
            {
                throw new Exception("Cannot find id: " + id);
                return null;
            }
        }

        public async Task<int> UpdateInterviewFeedBackAsync(InterviewFeedBackRequestModel model)
        {
            var existingIntervieweFeedBack = await interviewFeedBackRepositoryAsync.GetByIdAsync(model.InterviewFeedBackId);
            if (existingIntervieweFeedBack == null)
            {
                throw new Exception("Interview feedback with id: " + model.InterviewFeedBackId + " does not exist");
            }
            InterviewFeedBack inter = new InterviewFeedBack();
            if (model != null)
            {
                inter.InterviewFeedBackId = model.InterviewFeedBackId;
                inter.Rating = model.Rating;
                inter.Comment = model.Comment;
                return await interviewFeedBackRepositoryAsync.UpdateAsync(inter);
            }
            else
            {
                throw new Exception("Update fail");
                return -1;
            }
        }
    }
}
