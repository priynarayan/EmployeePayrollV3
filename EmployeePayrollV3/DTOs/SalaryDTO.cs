using EmployeePayrollV3.Models.DBModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeePayrollV3.DTOs
{
    public class SalaryDTO
    {
        [JsonIgnore]
        public int salaryId { get; set; }
        public int  JobClassId { get; set; }
        [JsonIgnore]
        public int BPay { get; set; }
        [JsonIgnore]
        public int TA { get; set; }
        [JsonIgnore]
        public int HA { get; set; }
        [JsonIgnore]
        public int MA { get; set; }
        public string BankAcc { get; set; }
        [Required]
        public int Amount { get; set; }
        public int Tax { get; set; }
        public int Bonus { get; set; }
    }
}
