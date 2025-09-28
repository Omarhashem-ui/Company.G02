using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.G02.Mvc.Dtos
{
    public class CreateEmployeedto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(12, 60, ErrorMessage = "Age must be between 22 and 60")]
        public int? Age { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
                ,ErrorMessage ="Address must be like 123-street-city-country")]
        public string Address { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("Hiring Date")]
        public DateTime HiringDate { get; set; }
        [DisplayName("Create At")]
        public DateTime CreateAt
        {
            get; set;
        }
    }
}
