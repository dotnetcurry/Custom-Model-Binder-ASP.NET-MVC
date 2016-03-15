using System.ComponentModel.DataAnnotations;

namespace MVC_CustomModelBinder.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
    }
}