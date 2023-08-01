using System.ComponentModel.DataAnnotations;

namespace DapperRepository.BusinessLayer.Entities
{
    public class Employee
    {
        public int id { get;set; }
        [Required]
        public string name { get;set; }=string.Empty;
        [EmailAddress]
        public string email { get;set; }= string.Empty;
        [Required]
        [Phone] 
        public string phone { get;set; } = string.Empty;
        public int age { get;set; }
        public string Address { get;set;} = string.Empty;
        public string City { get;set;} = string.Empty;
        [Required]
        public int salary { get;set; }
    }
}
