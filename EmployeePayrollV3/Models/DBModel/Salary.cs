using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeePayrollV3.Models.DBModel
{
    public class Salary
    {
        public int Id { get; set; }
        public int JobClassId { get; set; }
        [JsonIgnore]
        public JobClass JobClass { get; set; }
        [Required]
        public string BankAcc { get; set; }
        [Required]
        public int Amount { get; set; }
        public int Tax { get; set; }
        public int Bonus { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}
