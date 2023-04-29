using Recruiting.Core.Entity;
using Recruiting.Core.Models;
using Recruiting.Core.Repository;
using Recruiting.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infrastructure.Service
{
    public class SubmissionStatusServiceAsync : ISubmissionStatusServiceAsync
    {
        ISubmissionStatusRepositoryAsync submissionStatusRepository;
        public SubmissionStatusServiceAsync(ISubmissionStatusRepositoryAsync _submissionStatusRepositoryAsync)
        {
            this.submissionStatusRepository = _submissionStatusRepositoryAsync;
        }
        public async Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            SubmissionStatus status = new SubmissionStatus();
            try
            {
                if (model != null)
                {
                    status.LookupCode = model.LookupCode;
                    status.Description = model.Description;
                }
                return await submissionStatusRepository.InsertAsync(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: ", e);
                return 0;
            }
        }

        public async Task<int> DeleteSubmissionStatusAsync(int id)
        {
            return await submissionStatusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatus()
        {
            var collection = await submissionStatusRepository.GetByIdAsync();
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

        public async Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id)
        {
            var collection = await submissionStatusRepository.GetByIdAsync(id);
            if (collection != null)
            {
                    SubmissionStatusResponseModel model = new SubmissionStatusResponseModel();
                    model.LookupCode = collection.LookupCode;
                    model.Description = collection.Description;
                    return model;   
            }
            return null;
        }

        public async Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            var existingSubmissionStatus = await submissionStatusRepository.GetByIdAsync(model.LookupCode);
            if (existingSubmissionStatus == null)
            {
                throw new Exception("Candidate does not exist");
            }
            SubmissionStatus status = new SubmissionStatus();
            if (model != null)
            {
                status.LookupCode = model.LookupCode;
                status.Description = model.Description;
                return await submissionStatusRepository.UpdateAsync(status);
            }
            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}
