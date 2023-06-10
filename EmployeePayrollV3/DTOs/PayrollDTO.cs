using EmployeePayrollV3.Models.DBModel;
using System.Text.Json.Serialization;

namespace EmployeePayrollV3.DTOs
{
    public class PayrollDTO
    {
        [JsonIgnore]
        public int payrollId { get; set; }
        public int userId { get; set; }
        public int jobClassId { get; set; }
        public int salaryId { get; set; }
        [JsonIgnore]
        public int Amt { get; set; }
        [JsonIgnore]
        public int TaxCal { get; set; }
        [JsonIgnore]
        public int BonusCal { get; set; }
        public DateTime month { get; set; } = DateTime.Now;
        public string EmployeeName { get; set; }
        public string JobName { get; set; }
        public string RoleName { get; set; }
        public int NetSalary { get; set; }
    }
}
