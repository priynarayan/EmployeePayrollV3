using EmployeePayrollV3.Data;
using EmployeePayrollV3.Models.crudModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        //Payroll reciepts for admin and employee
        [HttpGet("GetSlip")]
        public IActionResult GetPAyroll(int id)
        {
            var PaySlipById = _dbContext.Payrolls.Where(u => u.Id == id).Select(p => new PayrollDetails
            {
                userId = p.userId,
                jobClassId = p.jobClassId,
                salaryId = p.salaryId,
                EmployeeName = p.EmployeeName,
                JobName = p.JobName,
                RoleName = p.RoleName,
                NetSalary = p.NetSalary,

            }).ToList();

            if(PaySlipById.Count == 0)
            {
                return NotFound("User Doest Not Found");
            }

            return Ok(PaySlipById);
        }
    }
}
