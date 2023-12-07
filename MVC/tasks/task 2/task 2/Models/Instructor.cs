using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public Decimal Salary { get; set; }

        public string Address { get; set; }

        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }

        public  Department Department { get; set; } // nav prop -> one

        [ForeignKey("Course")]
        public int? Crs_Id { get; set; }

        public  Course Course { get; set; } // nav prop -> one

    }
}
