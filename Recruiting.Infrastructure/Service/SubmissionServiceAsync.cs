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
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        ISubmissionRepositoryAsync submissionRepository;
        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissionService)
        {
            submissionRepository = _submissionService;
        }

        public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            Submission sub = new Submission();
            if (model != null)
            {
                sub.SubmissionId = model.SubmissionId;
                sub.JobRequirementId = model.JobRequirementId;
                sub.CandidateId = model.CandidateId;
                sub.SubmittedOn = model.SubmittedOn;
                sub.ConfirmedOn = model.ConfirmedOn;
                sub.RejectedOn = model.RejectedOn;
                sub.SubmissionStatusCode = model.SubmissionStatusCode;
            }
            //returns number of rows affected, typically 1
            return await submissionRepository.InsertAsync(sub);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            return await submissionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissions()
        {
            var collection = await submissionRepository.GetByIdAsync();
            if (collection != null)
            {
                List<SubmissionResponseModel> result = new List<SubmissionResponseModel>();
                foreach (var item in collection)
                {
                    SubmissionResponseModel model = new SubmissionResponseModel();
                    model.SubmissionId = item.SubmissionId;
                    model.JobRequirementId = item.JobRequirementId;
                    model.CandidateId = item.CandidateId;
                    model.SubmittedOn = item.SubmittedOn;
                    model.ConfirmedOn = item.ConfirmedOn;
                    model.RejectedOn = item.RejectedOn;
                    model.SubmissionStatusCode = item.SubmissionStatusCode;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var item = await submissionRepository.GetByIdAsync(id);
            if (item != null)
            {
                SubmissionResponseModel model = new SubmissionResponseModel();
                model.SubmissionId = item.SubmissionId;
                model.JobRequirementId = item.JobRequirementId;
                model.CandidateId = item.CandidateId;
                model.SubmittedOn = item.SubmittedOn;
                model.ConfirmedOn = item.ConfirmedOn;
                model.RejectedOn = item.RejectedOn;
                model.SubmissionStatusCode = item.SubmissionStatusCode;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            var existingSubmission = await submissionRepository.GetByIdAsync(model.SubmissionId);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            Submission sub = new Submission();
            if (model != null)
            {

                sub.SubmissionId = model.SubmissionId;
                sub.JobRequirementId = model.JobRequirementId;
                sub.CandidateId = model.CandidateId;
                sub.SubmittedOn = model.SubmittedOn;
                sub.ConfirmedOn = model.ConfirmedOn;
                sub.RejectedOn = model.RejectedOn;
                sub.SubmissionStatusCode = model.SubmissionStatusCode;
                return await submissionRepository.UpdateAsync(sub);
            }
            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}
