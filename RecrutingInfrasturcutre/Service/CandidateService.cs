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
    public class CandidateService : ICandidateService
    {
      ICandidateRepository candidateRepository;
        public CandidateService(ICandidateRepository _candidateRepository)
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
                    //candidate.Id = model.Id;
                    candidate.FirstName = model.FirstName;
                    candidate.LastName = model.LastName;
                    candidate.EmailId = model.EmailId;
                    candidate.ResumeURL = model.ResumeURL;
                }
                //returns number of rows affected, typically 1
                return await candidateRepository.InsertAsync(candidate);
            }
            catch(Exception e)
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
                    model.Id = item.Id;
                    model.FirstName = item.FirstName;
                    model.LastName = item.LastName;
                    model.EmailId = item.EmailId;
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
                model.Id = collection.Id;
                model.FirstName = collection.FirstName;
                model.LastName = collection.LastName;
                model.EmailId = collection.EmailId;
                model.ResumeURL = collection.ResumeURL;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await candidateRepository.GetByIdAsync(model.Id);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.Id = model.Id;
                candidate.FirstName = model.FirstName;
                candidate.LastName = model.LastName;
                candidate.EmailId = model.EmailId;
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
