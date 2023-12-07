using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class SrcResult
    {
        public int Id { get; set; }

        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int? Crs_Id { get; set; }

        public  Course Course { get; set; } // nav prop -> one

        [ForeignKey("Trinee")]
        public int? Trinee_Id { get; set; }

        public  Trinee Trinee { get; set; } // nav prop -> one

    }
}
