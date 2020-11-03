using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            UniversityBind(); 
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Student_ID,Student_Email,Student_FirstName,Student_LastName,Student_UniversityNumber,Student_ContactNumber,Student_Password,confirmPassword,University_Name,Campus_Name")]StudentRegister uc)
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

        public void UniversityBind()
        {
            DbSet<DBUniversity> ds = _auc.University;
            List<SelectListItem> unilist = new List<SelectListItem>();
            foreach (DBUniversity dr in ds)
            {

                unilist.Add(new SelectListItem { Text = dr.Uni_Name.ToString(), Value = dr.Uni_ID.ToString() });

            }
            ViewBag.university = unilist;
        }

        public JsonResult campusBind(string uni_id)
        {

            var ds = _auc.Campus.Where(c => c.University_ID == uni_id);
            List<SelectListItem> campusList = new List<SelectListItem>();
            foreach (DBCampus dr in ds)
            {
                campusList.Add(new SelectListItem { Text = dr.Campus_Name.ToString(), Value = dr.Campus_ID.ToString() });
            }
            return Json(campusList, new Newtonsoft.Json.JsonSerializerSettings());

        }

    }
}
