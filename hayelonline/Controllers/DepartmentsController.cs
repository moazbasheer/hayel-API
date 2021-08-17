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

    }
    
}
