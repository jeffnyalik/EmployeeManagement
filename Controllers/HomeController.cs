using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting.Internal;

namespace EmployeeManagement.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;

        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.getAllEmployees();
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("NotFoundCode", id.Value); //Status code Message view.
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult Create(EmployCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null; //Photo file name
                if(model.Photos != null && model.Photos.Count > 0)
                {
                    foreach (IFormFile photo in model.Photos) {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                   
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpGet]
        
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditView = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditView);
        }

        [HttpPost]
        
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department; 
                if(model.Photos != null) {
                    if(model.ExistingPhotoPath != null)
                    {  

                       string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                       System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model); //Photo file name
                }

                _employeeRepository.Update(employee);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(EmployCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

            }

            return uniqueFileName;
        }

        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("index");
        }
    }
}