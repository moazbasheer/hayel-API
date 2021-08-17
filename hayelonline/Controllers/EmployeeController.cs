using hayelonline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hayelonline.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllEmployees()
        {
            return Json(new { data = await _db.Employees.ToListAsync() });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var myEmployee = _db.Employees.Find(id);
            if (myEmployee == null)
            {
                return RedirectToAction("Index");
            }
            _db.Employees.Remove(myEmployee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return View();
            }
            var Employee = _db.Employees.Find(Id);
            if (Employee == null)
            {
                return View();
            }
            return View(Employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(Employee);
                _db.SaveChanges();
            }
            return RedirectToAction("Edit");
        }


        [HttpPost]
        public IActionResult InsertEmployee(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(Employee);
                _db.SaveChanges();
            }
            return RedirectToAction("Edit");
        }
    }
}
