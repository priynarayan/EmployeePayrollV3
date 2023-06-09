using System.Text.Json.Serialization;

namespace EmployeePayrollV3.Models.DBModel
{
    public class JobClass
    {
        public int Id { get; set; }
        public string JobDescription { get; set; }
        public int BasicPay { get; set; }
        public int TravelAllowance { get; set; }
        public int MedicalAllowance { get; set; }
        public int HouseAllowance { get; set; }
        public ICollection<Salary> SalaryList { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}
