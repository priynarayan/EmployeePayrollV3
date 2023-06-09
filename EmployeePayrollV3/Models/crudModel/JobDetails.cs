namespace EmployeePayrollV3.Models.crudModel
{
    public class JobDetails
    {
        public int jobId { get; set; }
        public string JobDescription { get; set; }
        public int BasicPay { get; set; }
        public int TravelAllowance { get; set; }
        public int MedicalAllowance { get; set; }
        public int HouseAllowance { get; set; }
    }
}
