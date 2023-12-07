using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be more than 2 letter")]
        [MaxLength(25)]
        [Uniqe]
        public string Name { get; set; }


        [Range(minimum: 50, maximum: 100)]
        public int Degree { get; set; }


        [Remote("CheckMinDegree", "Course"
           , AdditionalFields = "Degree"
           , ErrorMessage = "Min Degree must be less than Degree")]
        public int MinDegree { get; set; }


        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }

        public  Department? Department { get; set; } // nav prop -> one

        public  ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>(); //nav prop -> many
        public  ICollection<SrcResult> SrcResults { get; set; } = new HashSet<SrcResult>(); //nav prop -> many


    }
}
