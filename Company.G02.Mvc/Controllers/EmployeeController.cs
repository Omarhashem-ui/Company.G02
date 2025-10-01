using AutoMapper;
using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Models;
using Company.G02.Mvc.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.G02.Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeController(
              IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository,
             IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public IActionResult Index(string? searchinput)
        {
            IEnumerable<Employee> employee;
            if (string.IsNullOrEmpty(searchinput) ) 
            {
                 employee = _employeeRepository.GetAll();
               
            }
            else
            {
                 employee = _employeeRepository.GetByName(searchinput);
               
            }
       
            // Dictionary : 3 properties
            //1-view data : obJ must implicit Data taype ,  Transfer Extra Information from  Controller to View
            //ViewData["Massege"] = "Hello from View Data";
            //2- View Bag : Dynamic Object (No Intellisense),  Transfer Extra Information from  Controller to View
           ViewBag.Massege = "Hello from View Bag";
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var departments = _departmentRepository.GetAll();
            ViewData["Departments"] = departments;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(CreateEmployeedto model)
        {
            if (ModelState.IsValid)
            {
                //var emp = new Employee()
                //{
                //    Name = model.Name,
                //    Age = model.Age,
                //    Email = model.Email,
                //    Address = model.Address,
                //    Phone = model.Phone,
                //    Salary = model.Salary,
                //    IsActive = model.IsActive,
                //    IsDeleted = model.IsDeleted,
                //    HiringDate = model.HiringDate,
                //    CreateAt = model.CreateAt,
                //    DepartmentId = model.DapartmentId

                //};
                var emp = _mapper.Map<Employee>(model);
                var count = _employeeRepository.Add(emp);
                if (count > 0)
                    TempData["success"] = "Employee Created Successfully";
                return RedirectToAction("Index");
            }

          

            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int? id, string Actionname = "Details")
        {
            var departments = _departmentRepository.GetAll();
            ViewData["Departments"] = departments;
            if (id == null || id == 0)
            {
                return BadRequest("Invalid Id");
            }

            var model = _employeeRepository.Get(id.Value);
            if (model == null)
                return NotFound();
            return View(model);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var departments = _departmentRepository.GetAll();
            ViewData["Departments"] = departments;
            if (id == null || id == 0)
            {
                return BadRequest("Invalid Id");
            }

            var emp = _employeeRepository.Get(id.Value);
            if (emp == null)
                return NotFound();
            //var employeedto = new CreateEmployeedto()
            //{
            //    Name = emp.Name,
            //    Age = emp.Age,
            //    Email = emp.Email,
            //    Address = emp.Address,
            //    Phone = emp.Phone,
            //    Salary = emp.Salary,
            //    IsActive = emp.IsActive,
            //    IsDeleted = emp.IsDeleted,
            //    HiringDate = emp.HiringDate,
            //    CreateAt = emp.CreateAt
            //};
            var employeedto = _mapper.Map<CreateEmployeedto>(emp);
            return View(employeedto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, CreateEmployeedto model)
        {
            if (ModelState.IsValid)
            {
                //if (id != emp.Id)
                //{
                //    return BadRequest("Id Mismatched");
                //}
                var emp = new Employee()
                {
                    Id = id,
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    HiringDate = model.HiringDate,
                    CreateAt = model.CreateAt,
                    DepartmentId = model.DapartmentId
                };

                var count = _employeeRepository.Update(emp);
                if (count > 0)
                    return RedirectToAction("Index");
            }

            return View(model);


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
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Employee emp)
        {
            var departments = _departmentRepository.GetAll();
            ViewData["Departments"] = departments;
            if (ModelState.IsValid)
            {
                if (id != emp.Id)
                {
                    return BadRequest("Id Mismatched");
                }
                var model = _employeeRepository.Delete(emp);
                if (model > 0)
                    return RedirectToAction("Index");
            }

            return View(emp);


        }


    }
}
