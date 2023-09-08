using Azure;
using DapperRepository.BusinessLayer.Entities;
using DapperRepository.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data;

namespace DapperRepository
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {


        private readonly IConfiguration _config;
        private readonly IEmployeeRepo _employeeRepo;
        public EmpController(IConfiguration configuration, IEmployeeRepo employeeRepo)
        {
            _config = configuration;
            _employeeRepo = employeeRepo;
        }

        [HttpGet("AllEmployee")]
        public async Task<IActionResult> GetAllEmp()
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = " All records found successsfully../";
            try
            {
                dtoResponse = await _employeeRepo.AllEmpRecord();

            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);

        }
        [HttpGet("GetEmployeeByID")]
        public async Task<IActionResult> GetAllEmpbyid(int id)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record found successsfully.....////";
            try
            {
                dtoResponse = await _employeeRepo.AllEmpById(id);

            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);
        }
        [HttpGet("RemoveEmployeeByID")]
        public async Task<IActionResult> RemoveAllEmpbyid(int id)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "Record Deleted successsfully.....////";
            try
            {
                dtoResponse = await _employeeRepo.RemoveEmp(id);

            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);
        }





        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmp( Employee employee)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record found successsfully.....////";
            try
            {
                dtoResponse = await _employeeRepo.AddEmp(employee);

            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);

        }

        [HttpPost("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmp(Employee employee)
        {
            DtoResponse dtoResponse = new DtoResponse();
            dtoResponse.status = true;
            dtoResponse.Message = "record Updated successsfully.....////";
            try
            {
                dtoResponse = await _employeeRepo.UpdateEmp(employee);

            }
            catch (Exception ex)
            {
                dtoResponse.status = false;
                dtoResponse.Message = "Excetion has occurs";
                dtoResponse.ErrorMessage = ex.Message;
            }

            return Ok(dtoResponse);

        }


    }
}