using hayelonline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hayelonline.Controllers
{
    public class DepartmentsController : Controller
    {
        public readonly ApplicationDbContext _db;
        public DepartmentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? Id)
        {
            if(Id == null)
            {
                return View();
            }
            var Department = _db.Departments.Find(Id);
            if(Department == null)
            {
                return View();
            }
            return View(Department);
        }
        [HttpPost]
        public IActionResult Upsert(Department Department)
        {
            if (ModelState.IsValid)
            {
                if(Department.Id == 0)
                {
                    _db.Departments.Add(Department);
                    _db.SaveChanges();
                }
                else 
                { 
                    _db.Departments.Update(Department);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateDepartment(Department Department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(Department);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult InsertDepartment(Department Department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(Department);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var myDepartment = _db.Departments.Find(id);
            if(myDepartment == null)
            {
                return RedirectToAction("Index");
            }
            _db.Departments.Remove(myDepartment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetAllDepartments()
        {
            return Json(new { data = await _db.Departments.ToListAsync() });
        }

        [HttpPost]
        public IActionResult Insert(Department Department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(Department);
                _db.SaveChanges();
                return Json(new { data = "Department inserted successfully" });
            }
            return Json(new { data = "data is not correct!" });
        }
        [HttpPost]
        public IActionResult Update(Department Department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(Department);
                _db.SaveChanges();
                return Json(new { data = "Department updated successfully" });
            }
            return Json(new { data = "data is not correct!" });
        }
        public IActionResult DeleteDepartment(int? id)
        {
            if (id == null)
            {
                return Json(new { data = "Input a correct id!" });
            }
            var Department = _db.Departments.Find(id);
            if (Department == null)
            {
                return Json(new { data = "Input a correct id!" });
            }
            _db.Departments.Remove(Department);
            _db.SaveChanges();
            return Json(new { data = "Department is deleted successfully!" });
        }
    }
    
}
