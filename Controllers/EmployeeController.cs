using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Operation_In_MVC_ForeignKey.Controllers
{
    public class EmployeeController : Controller
    {

        TutorialsCS _context = new TutorialsCS();
        public ActionResult Index()
        {
            var listofData = _context.Employees.ToList();
            return View(listofData);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            var listofData = _context.Employees.ToList();
            ViewBag.Message = "Data Insert Successfully";
            return View("Index", listofData);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee Model)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
            if (data != null)
            {
                data.EmployeeCity = Model.EmployeeCity;
                data.EmployeeName = Model.EmployeeName;
                data.EmployeeSalary = Model.EmployeeSalary;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }



    }
}