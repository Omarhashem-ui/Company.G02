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
        [HttpGet]
        public IActionResult Details(int? id , string Actionname = "Details")
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid Id");
            }

            var model = _departmentRepository.Get(id.Value); 
            if (model == null)
                return NotFound();
            return View(model); 

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid Id");
            }

            var model = _departmentRepository.Get(id.Value);
            if (model == null)
                return NotFound();
            var departmentdto = new CreateDepartmentdto()
            {
                Code = model.Code,
                Name = model.Name,
                CrateAt = model.CrateAt
            };
            return View(departmentdto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateDepartmentdto department)
        {
            if (ModelState.IsValid)
            {
               var Dept = new Department()
                {
                    Id = id,
                    Code = department.Code,
                    Name = department.Name,
                    CrateAt = department.CrateAt
               };
                
                var model = _departmentRepository.Update(Dept);
                if (model > 0)
                    return RedirectToAction("Index");
            }

            return View(department);


        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id == null || id == 0)
            //{
            //    return BadRequest("Invalid Id");
            //}

            //var model = _departmentRepository.Get(id.Value);
            //if (model == null)
            //    return NotFound();
            return Details(id,"Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id)
                {
                    return BadRequest("Id Mismatched");
                }
                var model = _departmentRepository.Delete(department);
                if (model > 0)
                    return RedirectToAction("Index");
            }

            return View(department);


        }
           

    }
}          

