using EmployeePayrollV3.Data;
using EmployeePayrollV3.DTOs;
using EmployeePayrollV3.Models.crudModel;
using EmployeePayrollV3.Models.DBModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        //Adding Salary Details for Users
        [HttpPost("[action]")]
        public IActionResult AddSalaryDetails(SalaryDTO sal)
        {
            //var salaryDetail = _dbContext.Salaries.FirstOrDefault(u => u.Id == sal.salaryId);
            //if (salaryDetail != null)
            //{
            //    return BadRequest("Employee salary already exists");
            //}

            //var netSal = 0;
            //foreach (var sl in _dbContext.JobClasses)
            //{
            //    if (salaryDetail.JobClassId == sl.Id)
            //    {
            //        netSal = sl.BasicPay + sl.TravelAllowance + sl.MedicalAllowance + sl.HouseAllowance;
            //        break;
            //    }
            //}

            //var newSal = new Salary()
            //{
            //    JobClassId = sal.JobClassId,
            //    BankAcc = sal.BankAcc,
            //    Amount = netSal,
            //    Tax = sal.Tax,
            //    Bonus = sal.Bonus,
            //};

            //_dbContext.Salaries.Add(newSal);
            //_dbContext.SaveChanges();
            //return Ok("Salary details added successfully");


            var salaryDetail = _dbContext.Salaries.FirstOrDefault(u => u.Id == sal.salaryId);
            if (salaryDetail != null)
            {
                return BadRequest("Employee salary already exists");
            }


            JobClass jobClass = _dbContext.JobClasses.FirstOrDefault(j => j.Id == sal.JobClassId);
            if(jobClass == null)
            {
                return NotFound("No any Job details found for the user");
            }
            
            sal.BPay = jobClass.BasicPay;
            sal.TA = jobClass.TravelAllowance;
            sal.HA = jobClass.HouseAllowance;
            sal.MA = jobClass.MedicalAllowance;

            int Netsalary = sal.BPay + sal.TA + sal.HA + sal.MA;

            var EmployeeSalary = new Salary
            {
                JobClassId = sal.JobClassId,
                BankAcc = sal.BankAcc,
                Amount = Netsalary,
                Tax = sal.Tax,
                Bonus = sal.Bonus,
            };

            _dbContext.Salaries.Add(EmployeeSalary);
            _dbContext.SaveChanges();
            return Ok();

        }



        //Getting Salary Detail List
        [HttpGet("SalaryDetailList")]
        public IActionResult SalaryDetailList()
        {
            var salaryDetails = _dbContext.Salaries.Select(u => new SalaryDetails
            {
                salaryId = u.Id,
                JobClassId = u.JobClassId,
                BankAcc = u.BankAcc,
                Amount = u.Amount,
                Tax = u.Tax,
                Bonus = u.Bonus,

            }).ToList();
            if (salaryDetails.Count == 0)
            {
                return NotFound("No salary details found");
            }

            return Ok(salaryDetails);
        }

        //Getting SalaryDetails by their ID
        [HttpGet("SalaryById")]
        public IActionResult SalaryDetailById(int id)
        {
            var salaryDetailsById = _dbContext.Salaries.Where(p => p.Id == id).Select(u => new SalaryDetails
            {
                salaryId = u.Id,
                JobClassId = u.JobClassId,
                BankAcc = u.BankAcc,
                Amount = u.Amount,
                Tax = u.Tax,
                Bonus = u.Bonus,

            }).ToList();
            if (salaryDetailsById.Count == 0)
            {
                return NotFound("no salary details found");
            }

            return Ok(salaryDetailsById);
        }


        //Updating Salary details
        [HttpPut("UpdateSalary")]
        public IActionResult UserUpdate(int id, SalaryDTO sal)
        {
            JobClass jobClass = _dbContext.JobClasses.FirstOrDefault(j => j.Id == sal.JobClassId);
            if (jobClass == null)
            {
                return NotFound("No any Job details found for the user");
            }

            sal.BPay = jobClass.BasicPay;
            sal.TA = jobClass.TravelAllowance;
            sal.HA = jobClass.HouseAllowance;
            sal.MA = jobClass.MedicalAllowance;

            int Netsalary = sal.BPay + sal.TA + sal.HA + sal.MA;


            var currentSalary = _dbContext.Salaries.FirstOrDefault(u => u.Id == id);
            if (currentSalary != null)
            {
                currentSalary.JobClassId = sal.JobClassId;
                currentSalary.BankAcc = sal.BankAcc;
                currentSalary.Amount = Netsalary;
                currentSalary.Tax = sal.Tax;
                currentSalary.Bonus = sal.Bonus;

                _dbContext.SaveChanges();
                return Ok("Salary Details Updated successfully");
            }
            return NotFound("No salary details Found");
        }



        //deleting Salary details
        [HttpDelete("DeleteSalaryDetail")]
        public IActionResult SalaryDetailsDelete(int id)
        {
            var Salarydetailstodelete = _dbContext.Salaries.Find(id);
            if (Salarydetailstodelete == null)
            {
                return NotFound("No salary details Found");
            }

            _dbContext.Salaries.Remove(Salarydetailstodelete);
            _dbContext.SaveChanges();
            return Ok("salary details deleted successfully");
        }
    }
}
