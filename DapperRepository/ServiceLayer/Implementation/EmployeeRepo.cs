using Dapper;
using DapperRepository.BusinessLayer.Entities;
using DapperRepository.ServiceLayer.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DapperRepository.ServiceLayer.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfiguration _config;
        public EmployeeRepo(IConfiguration config)
        {
            _config = config;   
        }
        public async Task<DtoResponse> AddEmp(Employee employee)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record  Added successfully......!!";
            try
            {
                dtoResponse.data = new List<Employee>();
                using var conn = new SqlConnection(_config.GetConnectionString("cs"));

                dtoResponse.data = await conn.ExecuteAsync("insert into  Employees(name,email,phone,age,Address,City,salary) values(@name,@email,@phone,@age,@Address,@City,@salary)", employee);
            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs " + ex.Message;

            }
            return dtoResponse;
        }

        public  async Task<DtoResponse> AllEmpById(int Id)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record  fetched successfully......!!";
            try
            {
                dtoResponse.data = new List<Employee>();
                using var conn = new SqlConnection(_config.GetConnectionString("cs"));

                dtoResponse.data = await conn.QueryAsync<Employee>("select * from  Employees where Rid=@Id ", new { id = Id });
            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs" + ex.Message;

            }
            return dtoResponse;
        }

        public async Task<DtoResponse> AllEmpRecord()
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record  fetched successfully......!!";
            try
            {
                dtoResponse.data = new List<Employee>();
                using var conn = new SqlConnection(_config.GetConnectionString("cs"));

                dtoResponse.data = await conn.QueryAsync<Employee>("select * from  Employees ");
            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs" + ex.Message;

            }
            return dtoResponse;
        }

        public async Task<DtoResponse> RemoveEmp( int Id)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record  fetched successfully......!!";
            try
            {
                dtoResponse.data = new List<Employee>();
                using var conn = new SqlConnection(_config.GetConnectionString("cs"));

                dtoResponse.data = await conn.QueryAsync<Employee>("delete from  Employees where Rid=@Id ", new { id = Id });
            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs" + ex.Message;

            }
            return dtoResponse;
        }
        public async Task<DtoResponse> UpdateEmp(Employee employee)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record  fetched successfully......!!";
            try
            {
                dtoResponse.data = new List<Employee>();
                using var conn = new SqlConnection(_config.GetConnectionString("cs"));

                dtoResponse.data = await conn.ExecuteAsync(" update Employees set name=@name,email=@email,phone=@phone,age=@age,Address=@Address,City=@City,salary=@salary where id=@id", employee);
            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs " + ex.Message;

            }
            return dtoResponse;
        }


    }
}
