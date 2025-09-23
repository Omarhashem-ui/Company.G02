using Company.G02.BLL.Interfaces;
using Company.G02.BLL.Repository;
using Company.G02.DAL.Models;
using Company.G02.Mvc.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
      
        [HttpGet] //   /Department/Index    
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();

            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentdto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CrateAt = model.CrateAt
                };
                var count=_departmentRepository.Add(department);
                if(count>0)
                    return RedirectToAction("Index");

            }
            return View();
        }
  

    }
}
