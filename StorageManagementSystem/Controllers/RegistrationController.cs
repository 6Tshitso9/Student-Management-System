using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorageManagementSystem.Models;

namespace StorageManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationUser _auc;

        public RegistrationController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentRegister uc)
        {
            DBStudent cur = new DBStudent();
            cur.Student_ID = uc.Student_ID;
            cur.Student_FirstName = uc.Student_FirstName;
            cur.Student_LastName = uc.Student_LastName;
            cur.Student_Password = uc.Student_Password;
            cur.Student_UniversityNumber = uc.Student_UniversityNumber;
            cur.Student_Email = uc.Student_Email;
            cur.Campus_ID = 1;
            cur.Student_ContactNumber = uc.Student_ContactNumber;
            try
            {
                _auc.Add(cur);
                _auc.SaveChanges();
                ViewBag.message = "You have successfully registered";
                return View();
            } 
            catch  (Exception e)
            {
                return Index();
            }
           
        }
    }
}
