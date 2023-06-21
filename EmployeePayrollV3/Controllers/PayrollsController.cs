using EmployeePayrollV3.Data;
using EmployeePayrollV3.DTOs;
using EmployeePayrollV3.Models.crudModel;
using EmployeePayrollV3.Models.DBModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmployeePayrollV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollsController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        //Adding some details for users
        [HttpPost("[action]")]
        public IActionResult AddUserDetail(PayrollDTO pays)
        {
            var payDetail = _dbContext.Payrolls.FirstOrDefault(p =>  p.Id == pays.payrollId);
            if(payDetail != null)
            {
                return BadRequest("Payroll Already Exists");
            }

            Salary salary = _dbContext.Salaries.FirstOrDefault(s => s.Id == pays.salaryId);
            if(salary == null)
            {
                return NotFound("Job Detail and Salary Not Available");
            }

            User user = _dbContext.Users.FirstOrDefault(u => u.Id == pays.userId);
            if(user == null)
            {
                return NotFound("User Not Found");
            }

            JobClass jobClass = _dbContext.JobClasses.FirstOrDefault(j => j.Id == pays.jobClassId);
            if (jobClass == null)
            {
                return NotFound("No any Job details found for the user");
            }

            pays.Amt = salary.Amount;
            pays.TaxCal = salary.Tax;
            pays.BonusCal = salary.Bonus;

            int NetSalaryCal = 0;
            pays.Amt = pays.Amt - (int)((pays.TaxCal * pays.Amt) / 100);
            NetSalaryCal = pays.BonusCal + pays.Amt;

             //pays.EmployeeName = user.FirstName + " " + user.LastName;
             //pays.JobName = jobClass.JobDescription;


            var EmployeePayroll = new Payroll
            {
                userId = pays.userId,
                salaryId = pays.salaryId,
                jobClassId = pays.jobClassId,
                month = pays.month,
                EmployeeName = pays.EmployeeName,
                JobName = pays.JobName,
                RoleName = pays.RoleName,
                NetSalary = NetSalaryCal
            };

            _dbContext.Payrolls.Add(EmployeePayroll);
            _dbContext.SaveChanges();
            return Ok("Details Added Successfully");

        }


        //Payroll reciepts for admin and employee
        [HttpGet("GetSlipById")]
        public IActionResult GetPayroll(int id)
        {
            var PaySlipById = _dbContext.Payrolls.Where(u => u.Id == id).Select(p => new PayrollDetails
            {
                payrollId = p.Id,
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


        //updating Payroll details
        [HttpPut("updateDetail")]
        [Authorize(Roles = "Admin")]


        public IActionResult UpdatePayroll(int id, PayrollDTO pays)
        {
            
            Salary salary = _dbContext.Salaries.FirstOrDefault(s => s.Id == pays.salaryId);
            if (salary == null)
            {
                return NotFound("Job Detail and Salary Not Available");
            }

            User user = _dbContext.Users.FirstOrDefault(u => u.Id == pays.userId);
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            JobClass jobClass = _dbContext.JobClasses.FirstOrDefault(j => j.Id == pays.jobClassId);
            if (jobClass == null)
            {
                return NotFound("No any Job details found for the user");
            }

            pays.Amt = salary.Amount;
            pays.TaxCal = salary.Tax;
            pays.BonusCal = salary.Bonus;

            int NetSalaryCal = 0;
            pays.Amt = pays.Amt - (int)((pays.TaxCal * pays.Amt) / 100);
            NetSalaryCal = pays.BonusCal + pays.Amt;

            var CurrentPayroll = _dbContext.Payrolls.FirstOrDefault(p => p.Id == id);
            if(CurrentPayroll != null)
            {
                CurrentPayroll.userId = pays.userId;
                CurrentPayroll.jobClassId = pays.jobClassId;
                CurrentPayroll.salaryId = pays.salaryId;
                CurrentPayroll.EmployeeName = pays.EmployeeName;
                CurrentPayroll.JobName = pays.JobName;
                CurrentPayroll.RoleName = pays.RoleName;
                CurrentPayroll.NetSalary = NetSalaryCal;

                _dbContext.SaveChanges();
                return Ok("Details Updated Successfully");
            }

            return NotFound("Payroll Details Does not Exist");
            
        }

        //Deleting Payroll details
        [HttpDelete("deleteDetails")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePayroll(int id)
        {
            var payrollToDelete = _dbContext.Payrolls.Find(id);
            if(payrollToDelete  != null)
            {
                _dbContext.Payrolls.Remove(payrollToDelete);
                _dbContext.SaveChanges();
                return Ok("Payroll Details Deleted Successfully");
            }
            return NotFound("Payroll details Not Found");
        }
    }
}
