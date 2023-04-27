using RecruitingCore.Entity;
using RecruitingCore.Models;
using RecruitingCore.Repository;
using RecruitingCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingInfrastructure.Service
{
    public class SubmissionStatusService : ISubmissionStatusService
    {
        ISubmissionStatusRepository submissionStatusRepository;
        public SubmissionStatusService(ISubmissionStatusRepository submissionStatusRepository)
        {
            this.submissionStatusRepository = submissionStatusRepository;
        }

        public async Task<int> AddSubmissionAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus sub = new SubmissionStatus();
            if (model != null)
            {
                sub.LookupCode = model.LookupCode;
                sub.Description = model.Description;
            }
            //returns number of rows affected, typically 1
            return await submissionStatusRepository.InsertAsync(sub);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            return await submissionStatusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissions()
        {
            var collection = await submissionStatusRepository.GetAllAsync();
            if (collection != null)
            {
                List<SubmissionStatusResponseModel> result = new List<SubmissionStatusResponseModel>();
                foreach (var item in collection)
                {
                    SubmissionStatusResponseModel model = new SubmissionStatusResponseModel();
                    model.LookupCode = item.LookupCode;
                    model.Description = item.Description;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<SubmissionStatusResponseModel> GetSubmissionByIdAsync(int id)
        {
            var item = await submissionStatusRepository.GetByIdAsync(id);
            if (item != null)
            {
                SubmissionStatusResponseModel model = new SubmissionStatusResponseModel();
                model.LookupCode = item.LookupCode;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionStatusRequestModel model)
        {
            var existingSubmission = await submissionStatusRepository.GetByIdAsync(model.LookupCode);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            SubmissionStatus sub = new SubmissionStatus();
            if (model != null)
            {
                sub.LookupCode = model.LookupCode;
                sub.Description = model.Description;
                return await submissionStatusRepository.UpdateAsync(sub);
            }
            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}
