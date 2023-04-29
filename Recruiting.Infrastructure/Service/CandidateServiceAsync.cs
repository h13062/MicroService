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
    public class CandidateServiceAsync : ICandidateServiceAsync
    {
        ICandidateRepositoryAsync candidateRepository;
        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepository)
        {
            this.candidateRepository = _candidateRepository;
        }

        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {

            Candidate candidate = new Candidate();
            try
            {
                if (model != null)
                {
                    candidate.CandidateId = model.CandidateId;
                    candidate.FirstName = model.FirstName;
                    candidate.MiddleName = model.MiddleName;
                    candidate.LastName = model.LastName;
                    candidate.Email = model.Email;
                    candidate.ResumeURL = model.ResumeURL;
                }
                //returns number of rows affected, typically 1
                return await candidateRepository.InsertAsync(candidate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: ", e);
                return 0;
            }

        }

        public async Task<int> DeleteCandidateAsync(int id)
        {
            return await candidateRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidates()
        {
            var collection = await candidateRepository.GetAllAsync();
            if (collection != null)
            {
                List<CandidateResponseModel> result = new List<CandidateResponseModel>();
                foreach (var item in collection)
                {
                    CandidateResponseModel model = new CandidateResponseModel();
                    model.CandidateId = item.CandidateId;
                    model.FirstName = item.FirstName;
                    model.LastName = item.LastName;
                    model.Email = item.Email;
                    model.ResumeURL = item.ResumeURL;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var collection = await candidateRepository.GetByIdAsync(id);
            if (collection != null)
            {

                CandidateResponseModel model = new CandidateResponseModel();
                model.CandidateId = collection.CandidateId;
                model.FirstName = collection.FirstName;
                model.MiddleName = collection.MiddleName;
                model.LastName = collection.LastName;
                model.Email = collection.Email;
                model.ResumeURL = collection.ResumeURL;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await candidateRepository.GetByIdAsync(model.CandidateId);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.CandidateId = model.CandidateId;
                candidate.FirstName = model.FirstName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
                return await candidateRepository.UpdateAsync(candidate);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}
