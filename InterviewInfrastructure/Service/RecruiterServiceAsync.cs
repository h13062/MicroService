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
    public class RecruiterServiceAsync : IRecruiterServiceAsync
    {
        IRecruiterRepositoryAsync recruiterRepositoryAsync;
        public RecruiterServiceAsync(IRecruiterRepositoryAsync _recruiterRepositoryAsync)
        {
            this.recruiterRepositoryAsync = _recruiterRepositoryAsync;
        }

        public async Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            Recruiter re = new Recruiter();
            if (model != null)
            {
               re.RecruiterId = model.RecruiterId;
               re.FistName = model.FistName;
               re.LastName = model.LastName;
               re.EmployeeId = model.EmployeeId;
            }
            return await recruiterRepositoryAsync.InsertAsync(re);
        }

        public async Task<int> DeleteRecruiterAsync(int id)
        {
            return await recruiterRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters()
        {
            var collection = await recruiterRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<RecruiterResponseModel> result = new List<RecruiterResponseModel>();
                foreach (var item in collection)
                {
                    RecruiterResponseModel model = new RecruiterResponseModel();
                    model.RecruiterId = item.RecruiterId;
                    model.FistName = item.FistName;
                    model.LastName = item.LastName;
                    model.EmployeeId = item.EmployeeId;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var item = await recruiterRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                RecruiterResponseModel model = new RecruiterResponseModel();
                model.RecruiterId = item.RecruiterId;
                model.FistName = item.FistName;
                model.LastName = item.LastName;
                model.EmployeeId = item.EmployeeId;
                return model;
            }
            else
            {
                throw new Exception("Cannot find recruiter with id: " + id);
                return null;
            }
        }

        public async Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            var existingRecruiter = await recruiterRepositoryAsync.GetByIdAsync(model.RecruiterId);
            if (existingRecruiter == null)
            {
                throw new Exception("Recruiter with type code: " + model.RecruiterId + " does not exist");
            }
            Recruiter re = new Recruiter();
            if (model != null)
            {
                re.RecruiterId = model.RecruiterId;
                re.FistName = model.FistName;
                re.LastName = model.LastName;
                re.EmployeeId = model.EmployeeId;
                return await recruiterRepositoryAsync.UpdateAsync(re);
            }
            else
            {
                throw new Exception("Update recruiter table fail");
                return -1;
            }
        }
    }
}
