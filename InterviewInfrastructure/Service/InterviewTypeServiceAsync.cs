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
    public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {
        IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;
        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
        {
            this.interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }

        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType inter = new InterviewType();
            if (model != null)
            {
                inter.InterviewTypeCode = model.InterviewTypeCode;
                inter.Description = model.Description;
            }
            return await interviewTypeRepositoryAsync.InsertAsync(inter);
        }

        public async Task<int> DeleteInterviewTypeAsync(int id)
        {
            return await interviewTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes()
        {
            var collection = await interviewTypeRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<InterviewTypeResponseModel> result = new List<InterviewTypeResponseModel>();
                foreach (var item in collection)
                {
                    InterviewTypeResponseModel model = new InterviewTypeResponseModel();
                    model.InterviewTypeCode = item.InterviewTypeCode;
                    model.Description = item.Description;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var item = await interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                InterviewTypeResponseModel model = new InterviewTypeResponseModel();
                model.InterviewTypeCode = item.InterviewTypeCode;
                model.Description = item.Description;
                return model;
            }
            else
            {
                throw new Exception("Cannot find type code: " + id);
                return null;
            }
        }

        public async Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existingInterviewTypeCode = await interviewTypeRepositoryAsync.GetByIdAsync(model.InterviewTypeCode);
            if (existingInterviewTypeCode == null)
            {
                throw new Exception("Interview feedback with type code: " + model.InterviewTypeCode + " does not exist");
            }
            InterviewType inter = new InterviewType();
            if (model != null)
            {
                inter.InterviewTypeCode = model.InterviewTypeCode;
                inter.Description = model.Description;
                return await interviewTypeRepositoryAsync.UpdateAsync(inter);
            }
            else
            {
                throw new Exception("Update fail");
                return -1;
            }
        }
    }
}
