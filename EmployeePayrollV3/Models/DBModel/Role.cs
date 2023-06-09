using System.ComponentModel.DataAnnotations;

namespace EmployeePayrollV3.Models.DBModel
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string roleType { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
