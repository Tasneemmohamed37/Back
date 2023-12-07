using System.ComponentModel.DataAnnotations;

namespace task_2.Models
{
    public class UniqeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string? name = value.ToString();

            Course CrsFRomRequest = (Course)validationContext.ObjectInstance;


            ITIContext context = new ITIContext();

            Course CrsFromDB =context.Courses.FirstOrDefault(e => e.Name == name && e.Dept_Id == CrsFRomRequest.Dept_Id);


            if (CrsFromDB == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name Already Found");
            }
        }
    }
}

