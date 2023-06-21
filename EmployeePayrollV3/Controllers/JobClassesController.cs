using EmployeePayrollV3.Data;
using EmployeePayrollV3.Models.crudModel;
using EmployeePayrollV3.Models.DBModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobClassesController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        [HttpPost("[action]")]

        //Adding Job Details
        public IActionResult AddJobDetail(JobDetails jobs)
        {
            var userExists = _dbContext.JobClasses.FirstOrDefault(j => j.Id == jobs.jobId);
            if (userExists != null)
            {
                return BadRequest("Job Details already exists");
            }

            var jobDetail = new JobClass()
            {
                JobDescription = jobs.JobDescription,
                BasicPay = jobs.BasicPay,
                TravelAllowance = jobs.TravelAllowance,
                MedicalAllowance = jobs.MedicalAllowance,
                HouseAllowance = jobs.HouseAllowance,
            };

            _dbContext.JobClasses.Add(jobDetail);
            _dbContext.SaveChanges();
            return Ok("Job Details Added Successfully");

        }


        //Getting Job Detail List
        [HttpGet("JobDetailList")]
        public IActionResult jobList()
        {
            var jobDetail = _dbContext.JobClasses.Select(u => new JobDetails
            {
                jobId = u.Id,
                JobDescription = u.JobDescription,
                BasicPay = u.BasicPay,
                TravelAllowance = u.TravelAllowance,
                MedicalAllowance = u.MedicalAllowance,
                HouseAllowance = u.HouseAllowance,

            }).ToList();
            if (jobDetail.Count == 0)
            {
                return NotFound("No job details found");
            }

            return Ok(jobDetail);
        }

        //Getting Job Details by ID
        [HttpGet("JobDetailById")]
        public IActionResult jobListById(int id)
        {
            var jobDetailsById = _dbContext.JobClasses.Where(p=>p.Id == id).Select(u => new JobDetails
            {
                jobId = u.Id,
                JobDescription = u.JobDescription,
                BasicPay = u.BasicPay,
                TravelAllowance = u.TravelAllowance,
                MedicalAllowance = u.MedicalAllowance,
                HouseAllowance = u.HouseAllowance,

            }).ToList();
            if (jobDetailsById.Count == 0)
            {
                return NotFound("no job details found");
            }

            return Ok(jobDetailsById);
        }


        //Updating Job details by Admin
        [HttpPut("UpdateJobList")]
        [Authorize (Roles = "Admin")]
        public IActionResult UpdateJobListByid(int id, JobDetails jobs)
        {
            var jobToUpdated = _dbContext.JobClasses.FirstOrDefault(j => j.Id == id);
            if(jobToUpdated != null)
            {
                jobToUpdated.JobDescription = jobs.JobDescription;
                jobToUpdated.BasicPay = jobs.BasicPay;
                jobToUpdated.TravelAllowance = jobs.TravelAllowance;
                jobToUpdated.MedicalAllowance = jobs.MedicalAllowance;
                jobToUpdated.HouseAllowance = jobs.HouseAllowance;

                _dbContext.SaveChanges();
                return Ok("Job Details Updated Successfully");
            }

            return NotFound("Job Details Not Found");

        }


        //Deleting Job Details by id
        [HttpDelete("DeleteJobList")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteJobListById(int id)
        {
            var jobToDeleted = _dbContext.JobClasses.Find(id);
            if(jobToDeleted == null)
            {
                return NotFound("Job Details Not Found");
            }

            _dbContext.JobClasses.Remove(jobToDeleted);
            _dbContext.SaveChanges();
            return Ok("Job Details deleted SuccessFully");
        }

    }
}
