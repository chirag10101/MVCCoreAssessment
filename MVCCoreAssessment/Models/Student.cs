using System.ComponentModel.DataAnnotations;

namespace MVCCoreAssessment.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please provide Id")]
        [IdValidator]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage = "Only alphabets allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide DOB")]

        [DateOfBirthValidator]
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage ="Please enter batch")]
        [RegularExpression("B\\d{3}", ErrorMessage = "Batch should contain 4 character and end with 3 numbers")]
        public string Batch { get; set; }
    }
}
