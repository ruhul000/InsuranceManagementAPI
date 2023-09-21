using InsuranceManagementAPI.Data.Models;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InsuranceManagementAPI.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IBranchFactory _branchFactory;
        public BranchService(IBranchRepository branchRepository, IBranchFactory branchFactory)
        {
            _branchRepository = branchRepository;
            _branchFactory = branchFactory;
        }

        public async Task<Branch> Create(Branch branch)
        {
            Branch? response = null;
            var branchDto = _branchFactory.CreateFrom(branch);

            try
            {
                var insertedId = _branchRepository.Add(branchDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }
                
                branchDto.BranchKey = insertedId;

                response = _branchFactory.CreateFrom(branchDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public Task<bool> Delete(int BranchKey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Branch>> GetAll()
        {
            var branchDtos = await _branchRepository.GetAll();

            return _branchFactory.CreateMultipleFrom(branchDtos);
        }

        public async Task<IEnumerable<Branch>> GetAllByCompanyID(int ComKey)
        {
            var branchDtos = await _branchRepository.GetAllByCompanyID(ComKey);

            return _branchFactory.CreateMultipleFrom(branchDtos);
        }

        public async Task<Branch> GetById(int BranchKey)
        {
            var branchDto = await _branchRepository.GetByID(BranchKey);

            return _branchFactory.CreateFrom(branchDto);
        }

        public async Task<Branch> Update(Branch branch)
        {
            Branch? response = null;
            var branchDto = _branchFactory.CreateFrom(branch);

            try
            {
                var result = _branchRepository.Update(branchDto).Result;
                if (!result)
                {
                    return response;
                }
                branchDto = await _branchRepository.GetByID(branchDto.BranchKey);

                response = _branchFactory.CreateFrom(branchDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
    }
}
