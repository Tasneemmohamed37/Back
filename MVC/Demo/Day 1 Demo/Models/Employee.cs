using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_1_Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }


        [MinLength(3, ErrorMessage = "Name must be more than 2 letter")]
        [MaxLength(25)]
        [Uniqe]
        public string Name { get; set; }


        [Range(minimum: 4000, maximum: 30000)]
        [Required(ErrorMessage = "Salary Required")]
        public int Salary { get; set; }


        [Display(Name = "Home Address")]
        [RegularExpression("^(Alex|Cairo|Monofia)$"
            , ErrorMessage = "Address must be Alex or Cario or Monofia")]
        public string? Address { get; set; }


        [RegularExpression(@"^\w+\.(png|jpg)$", ErrorMessage = "image must be jpg or png")]
        public string? ImageURL { get; set; }


        [Remote("CheckAge", "Employee"
            , AdditionalFields = "Name"
            , ErrorMessage = "Age must be divided by 5")]
        public int Age { get; set; }



        [ForeignKey("Department")]
        [Display(Name ="Department")]
        public int? DeptId { get; set; }
        public Department? Department { get; set; } // navigational prop -> one
    }
}
