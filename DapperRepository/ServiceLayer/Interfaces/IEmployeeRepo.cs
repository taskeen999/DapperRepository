using Azure;
using DapperRepository.BusinessLayer.Entities;
using Microsoft.SqlServer.Server;

namespace DapperRepository.ServiceLayer.Interfaces
{
    public interface IEmployeeRepo
    {
        public Task<DtoResponse>AllEmpRecord ();
        public Task<DtoResponse> AllEmpById(int id);
        public Task<DtoResponse> AddEmp( Employee employee);
        public Task<DtoResponse> UpdateEmp(Employee employee);
        public Task<DtoResponse> RemoveEmp(int Id);
    }
}