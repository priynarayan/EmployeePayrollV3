using EmployeePayrollV3.Data;
using EmployeePayrollV3.Models.crudModel;
using EmployeePayrollV3.Models.DBModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeePayrollV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        private IConfiguration _config;

        public UsersController(IConfiguration config)
        {
            _config = config;
        }

        //Registration of Admin
        [HttpPost("[action]")]
        public IActionResult RegisterAdmin(UserDetails user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.EmailId == user.EmailId);
            if(userExists != null)
            {
                return BadRequest("User With same email id already exists");
            }

            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailId = user.EmailId,
                Password = user.Password,
                Gender = user.Gender,
                Age = user.Age,
                PhoneNumber = user.PhoneNumber,
                UserAddress = user.UserAddress,
                roleId = 1
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return Ok("Admin registered successfully");
        }


        //Registration of Employee
        [HttpPost("[action]")]
        public IActionResult RegisterEmployee(UserDetails user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.EmailId == user.EmailId);
            if (userExists != null)
            {
                return BadRequest("User With same email id already exists");
            }

            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailId = user.EmailId,
                Password = user.Password,
                Gender = user.Gender,
                Age = user.Age,
                PhoneNumber = user.PhoneNumber,
                UserAddress = user.UserAddress,
                roleId = 2
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return Ok("Employee registered successfully");
        }


        //Users Login
        [HttpPost("[action]")]
        public IActionResult LoginUser(UserLogin user)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.EmailId == user.EmailId);
            if(currentUser == null)
            {
                return NotFound("User Does Not Exists");
            }
            if(currentUser.Password != user.Password)
            {
                return NotFound("Incorrect Passwoed");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var role = _dbContext.Roles.Find(currentUser.roleId);

            var Claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, role.roleType),
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {Token = jwt, Message = "User Login Successfull" });

        }


        //Getting users detail list
        [HttpGet("EmployeeDetail")]
        public IActionResult GetEmployeeDetail()
        {
            var userDetail = _dbContext.Users.Select(u => new UserDetails
            {
                userId = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                EmailId = u.EmailId,
                Gender = u.Gender,
                Age = u.Age,
                PhoneNumber = u.PhoneNumber,
                UserAddress = u.UserAddress,
                roleId = u.roleId
            }).ToList();

            if(userDetail.Count==0)
            {
                return NotFound("Employee Details Not Found");
            }

            return Ok(userDetail);
        }

        //Getting user detail by id
        [HttpGet("EmployeeDetailById")]
        public IActionResult EmpDetailById(int id)
        {
            var empDetById = _dbContext.Users.Where(u => u.Id == id).Select(p => new UserDetails
            {
                userId = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                EmailId = p.EmailId,
                Gender = p.Gender,
                Age = p.Age,
                PhoneNumber = p.PhoneNumber,
                UserAddress = p.UserAddress,
                roleId = p.roleId
            }).ToList();

            if(empDetById.Count==0)
            {
                return NotFound("Employee Details Not Found");
            }

            return Ok(empDetById);
        }

        //Updating Employee Details
        [HttpPut("UpdateList")]
        [Authorize(Roles ="Admin")]
        public IActionResult UpdateEmpDetail(int id, UserDetails user)
        {
            var empToUpdated = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if(empToUpdated != null)
            {
                empToUpdated.FirstName = user.FirstName;
                empToUpdated.LastName = user.LastName;
                empToUpdated.EmailId = user.EmailId;
                empToUpdated.Gender = user.Gender;
                empToUpdated.PhoneNumber = user.PhoneNumber;
                empToUpdated.UserAddress = user.UserAddress;
                empToUpdated.roleId = user.roleId;

                _dbContext.SaveChanges();
                return Ok("Employee Details Updated Successfully");
            }

            return NotFound("Employee Not Found");
        }


        //Deleting Employee Details
        [HttpDelete("DeleteList")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmpDetail(int id)
        {
            var empToDeleted = _dbContext.Users.Find(id);
            if(empToDeleted == null)
            {
                return NotFound("Employee Not Found");
            }

            _dbContext.Users.Remove(empToDeleted);
            _dbContext.SaveChanges();
            return Ok("Employee Details Deleted Successfully");
        }



    }
}
