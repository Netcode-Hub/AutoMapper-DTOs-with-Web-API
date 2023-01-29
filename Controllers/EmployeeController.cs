using AutoMapper;
using EFCoreRelationships.Data;
using EFCoreRelationships.DTOs;
using EFCoreRelationships.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public EmployeeController(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseDTO>>> GetEmployees()
        {
            var employees = await appDbContext.Employees.ToListAsync();
            return Ok(employees.Select(mapper.Map<ResponseDTO>));
        }


        [HttpPost]
        public async Task<ActionResult<List<ResponseDTO>>> AddEmployee(RequestDTO newEmployee)
        {
            var employee = mapper.Map<Employee>(newEmployee);
            appDbContext.Employees.Add(employee);
            await appDbContext.SaveChangesAsync();

            var employees = await appDbContext.Employees.ToListAsync();
            return Ok(employees.Select(mapper.Map<ResponseDTO>));
        }
    }
}
