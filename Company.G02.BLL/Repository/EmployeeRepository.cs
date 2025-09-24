using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Dataa.Contexts;
using Company.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.BLL.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
            
        }
    }
}
