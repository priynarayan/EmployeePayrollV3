using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeePayrollV3.Models.DBModel
{
    public class User
    {
        public int Id { get; set; }
        public int roleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserAddress { get; set; }
        public ICollection<Payroll>Payrolls { get; set; }

    }
}
