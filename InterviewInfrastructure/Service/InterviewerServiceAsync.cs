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
    public class InterviewerServiceAsync : IInterviewerServiceAsync
    {
        IInterviewerRepositoryAsync interviewerRepositoryAsync;
        public InterviewerServiceAsync(IInterviewerRepositoryAsync _interviewerRepositoryAsync)
        {
            this.interviewerRepositoryAsync = _interviewerRepositoryAsync;
        }

        public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            Interviewer inter = new Interviewer();
            if (model != null)
            {
                inter.InterviewerID = model.InterviewerID;
                inter.FistName = model.FistName;
                inter.LastName = model.LastName;
                inter.EmployeeId = model.EmployeeId;
            }
            return await interviewerRepositoryAsync.InsertAsync(inter);
        }

        public async Task<int> DeleteInterviewerAsync(int id)
        {
            return await interviewerRepositoryAsync.DeleteAsync(id);   
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewers()
        {
            var collection = await interviewerRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<InterviewerResponseModel> result = new List<InterviewerResponseModel>();
                foreach (var item in collection)
                {
                    InterviewerResponseModel model = new InterviewerResponseModel();
                    model.InterviewerID = item.InterviewerID;
                    model.FistName = item.FistName;
                    model.LastName = item.LastName;
                    model.EmployeeId = item.EmployeeId;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id)
        {
            var item = await interviewerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                InterviewerResponseModel model = new InterviewerResponseModel();
                model.InterviewerID = item.InterviewerID;
                model.FistName = item.FistName;
                model.LastName = item.LastName;
                model.EmployeeId = item.EmployeeId;
                return model;
            }
            else
            {
                throw new Exception("Cannot find id: " + id);
                return null;
            }
        }
        public async Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            var existingInterviewer = await interviewerRepositoryAsync.GetByIdAsync(model.InterviewerID);
            if (existingInterviewer == null)
            {
                throw new Exception("Interview with: " + model.InterviewerID + " does not exist");
            }
            Interviewer inter = new Interviewer();
            if (model != null)
            {
                inter.InterviewerID = model.InterviewerID;
                inter.FistName = model.FistName;
                inter.LastName = model.LastName;
                inter.EmployeeId = model.EmployeeId;
                return await interviewerRepositoryAsync.UpdateAsync(inter);

            }
            else
            {
                throw new Exception("Update fail");
                return -1;
            }
        }
    }
}
