using System.ComponentModel.DataAnnotations;

namespace Company.G02.Mvc.Dtos
{
    public class UpdateDepartmentdto
    {
        [Required(ErrorMessage = "Code Is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CrateAt Is Required")]
        public DateTime CrateAt { get; set; }
    }
}
