using Recruiting.Core.Models;
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
        public Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSubmissionStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatus()
        {
            throw new NotImplementedException();
        }

        public Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
