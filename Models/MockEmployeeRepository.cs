using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private readonly List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
          {
              new Employee(){Id = 1, Name ="Jeff", Email = "jeffnyak@yahoo.com", Department = Enums.Dept.HR},
              new Employee(){Id = 2,  Name ="Bruce", Email = "bruce@gmail.com", Department =Enums.Dept.IT},
              new Employee(){Id = 3, Name ="Jeff", Email = "jeffnyak@yahoo.com", Department = Enums.Dept.Finance},
              new Employee(){Id = 4,  Name ="Bruce", Email = "bruce@gmail.com", Department =Enums.Dept.None},
              new Employee(){Id = 5, Name = "Krishna", Email="krishna@hotmail.com", Department=Enums.Dept.Payroll},
              new Employee(){Id = 6, Name = "Oloo", Email="oloo@gmail.com", Department=Enums.Dept.QualityAssurance}
          };
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;

        }

        public IEnumerable<Employee> getAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e=>e.Id == id);
        }

        public Employee Update(Employee employee)
        {
            Employee employee1 = _employeeList.FirstOrDefault(e => e.Id == employee.Id);
            if(employee1 != null)
            {
                employee1.Name = employee.Name;
                employee1.Email = employee.Email;
                employee1.Department = employee.Department;
            }

            return employee;
        }

        Employee IEmployeeRepository.Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    }
}
