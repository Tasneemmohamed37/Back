using System.ComponentModel.DataAnnotations;

namespace Day_1_Demo.Models
{
    public class UniqeAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string? name = value.ToString();
            Employee EmpFRomRequest =
                (Employee)validationContext.ObjectInstance;

            ITIContext context = new ITIContext();
            Employee EmpFromDB =
                context.Employees
                .FirstOrDefault(e => e.Name == name
                && e.DeptId == EmpFRomRequest.DeptId);


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
