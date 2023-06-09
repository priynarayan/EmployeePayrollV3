using System.Text.Json.Serialization;

namespace EmployeePayrollV3.Models.DBModel
{
    public class Payroll
    {
        public int Id { get; set; }
        public int userId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int jobClassId { get; set; }
        [JsonIgnore]
        public JobClass JobClass { get; set; }
        public int salaryId { get; set; }
        [JsonIgnore]
        public Salary Salary { get; set; }
        public DateTime month { get; set; } = DateTime.Now;
        public string EmployeeName { get; set; }
        public string JobName { get; set; }
        public string RoleName { get; set; }
        public int NetSalary { get; set; }


    }
}
