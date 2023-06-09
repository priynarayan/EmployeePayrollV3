using EmployeePayrollV3.Models.DBModel;
using System.Text.Json.Serialization;

namespace EmployeePayrollV3.Models.crudModel
{
    public class PayrollDetails
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int jobClassId { get; set; }
        public int salaryId { get; set; }
        //public DateTime month { get; set; } = DateTime.Now;
        public string EmployeeName { get; set; }
        public string JobName { get; set; }
        public string RoleName { get; set; }
        public int NetSalary { get; set; }
    }
}
