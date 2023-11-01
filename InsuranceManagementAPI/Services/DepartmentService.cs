using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Models;
using InsuranceManagementAPI.Models.Factories;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InsuranceManagementAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentFactory _departmentFactory;

        public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentFactory departmentFactory)
        {
            _departmentRepository = departmentRepository;
            _departmentFactory = departmentFactory;
        }
        public async Task<Department> Create(Department department)
        {
            Department? response = null;
            var departmentDto = _departmentFactory.CreateFrom(department);

            try
            {
                var insertedId = _departmentRepository.Add(departmentDto).Result;
                if (insertedId == 0)
                {
                    return response;
                }

                
                //departmentDto.DepKey = insertedId;

                response = _departmentFactory.CreateFrom(departmentDto);
            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        public  Task<bool> Delete(int DepId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var departmentDtos = await _departmentRepository.GetAll();

            return _departmentFactory.CreateMultipleFrom(departmentDtos);
        }

        public async Task<Department> GetById(int DepId)
        {
            var departmentDto = await _departmentRepository.GetByID(DepId);

            return _departmentFactory.CreateFrom(departmentDto);
        }

        public Task<Department> Update(Department department)
        {
            Department? response = null;
            var departmentDto = _departmentFactory.CreateFrom(department);

            try
            {
                var result = _departmentRepository.Update(departmentDto).Result;
                if (!result)
                {
                    return Task.FromResult<Department>(response);
                }



                response = _departmentFactory.CreateFrom(departmentDto);
            }
            catch (Exception ex)
            {
                return Task.FromResult<Department>(response);
            }

            return Task.FromResult(response);

        }
    }
}
