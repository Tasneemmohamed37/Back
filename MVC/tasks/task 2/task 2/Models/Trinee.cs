using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class Trinee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public Decimal Grade { get; set; }


        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }

        public  Department Department { get; set; } // nav prop -> one

        public  ICollection<SrcResult> SrcResults { get; set; } = new HashSet<SrcResult>(); //nav prop -> many


    }
}
