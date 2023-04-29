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
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        IJobRequirementRepositoryAsync jobRequirementRepository;
        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync jobRequirementRepository)
        {
            this.jobRequirementRepository = jobRequirementRepository;
        }

        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jr = new JobRequirement();
            if (model != null)
            {
                jr.JobRequirementId = model.JobRequirementId;
                jr.NumberOfPositions = model.NumberOfPositions;
                jr.Title = model.Title;
                jr.Description = model.Description;
                jr.HiringManagerId = model.HiringManagerId;
                jr.HiringManagerName = model.HiringManagerName;
                jr.StartDate = model.StartDate;
                jr.ClosedOn = model.ClosedOn;
                jr.ClosedReason = model.ClosedReason;
                jr.CreatedOn = model.CreatedOn;
                jr.JobCategory = model.JobCategory;
                jr.EmployeeType = model.EmployeeType;
            }
            //returns number of rows affected, typically 1
            return await jobRequirementRepository.InsertAsync(jr);
        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            return await jobRequirementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
        {
            var collection = await jobRequirementRepository.GetByIdAsync();
            if (collection != null)
            {
                List<JobRequirementResponseModel> result = new List<JobRequirementResponseModel>();
                foreach (var item in collection)
                {
                    JobRequirementResponseModel model = new JobRequirementResponseModel();
                    model.JobRequirementId = item.JobRequirementId;
                    model.NumberOfPositions = item.NumberOfPositions;
                    model.Title = item.Title;
                    model.Description = item.Description;
                    model.HiringManagerId = item.HiringManagerId;
                    model.HiringManagerName = item.HiringManagerName;
                    model.StartDate = item.StartDate;
                    model.ClosedOn = item.ClosedOn;
                    model.ClosedReason = item.ClosedReason;
                    model.CreatedOn = item.CreatedOn;
                    model.JobCategory = item.JobCategory;
                    model.EmployeeType = item.EmployeeType;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var item = await jobRequirementRepository.GetByIdAsync(id);
            if (item != null)
            {

                JobRequirementResponseModel model = new JobRequirementResponseModel();
                model.JobRequirementId = item.JobRequirementId;
                model.NumberOfPositions = item.NumberOfPositions;
                model.Title = item.Title;
                model.Description = item.Description;
                model.HiringManagerId = item.HiringManagerId;
                model.HiringManagerName = item.HiringManagerName;
                model.StartDate = item.StartDate;
                model.ClosedOn = item.ClosedOn;
                model.ClosedReason = item.ClosedReason;
                model.CreatedOn = item.CreatedOn;
                model.JobCategory = item.JobCategory;
                model.EmployeeType = item.EmployeeType;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingJobRequirement = await jobRequirementRepository.GetByIdAsync(model.JobRequirementId);
            if (existingJobRequirement == null)
            {
                throw new Exception("Job Requirement does not exist");
            }
            JobRequirement jr = new JobRequirement();
            if (model != null)
            {
                jr.JobRequirementId = model.JobRequirementId;
                jr.NumberOfPositions = model.NumberOfPositions;
                jr.Title = model.Title;
                jr.Description = model.Description;
                jr.HiringManagerId = model.HiringManagerId;
                jr.HiringManagerName = model.HiringManagerName;
                jr.StartDate = model.StartDate;
                jr.ClosedOn = model.ClosedOn;
                jr.ClosedReason = model.ClosedReason;   
                jr.CreatedOn = model.CreatedOn;
                jr.JobCategory = model.JobCategory;
                jr.EmployeeType = model.EmployeeType;
                return await jobRequirementRepository.UpdateAsync(jr);
            }
            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}
