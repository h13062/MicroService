﻿using Recruiting.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Service
{
    public interface ICandidateServiceAsync
    {
        Task<int> AddCandidateAsync(CandidateRequestModel model);
        Task<int> UpdateCandidateAsync(CandidateRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidates();
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
    }
}
