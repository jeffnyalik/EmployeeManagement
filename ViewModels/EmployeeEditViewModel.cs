using EmployeeManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeEditViewModel : EmployCreateViewModel
    {
      public int Id { get; set; }
      public string ExistingPhotoPath { get; set; }

    }
}
