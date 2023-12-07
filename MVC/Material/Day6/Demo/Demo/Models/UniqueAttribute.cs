using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    //Server side (api /MVC)
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string? name = value.ToString();
            Employee EmpFRomRequest=
                (Employee) validationContext.ObjectInstance;

            ITIContext context = new ITIContext();
            Employee EmpFromDB =
                context.Employees
                .FirstOrDefault(e => e.Name == name
                && e.DeptId== EmpFRomRequest.DeptId);


            if (EmpFromDB == null)
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
