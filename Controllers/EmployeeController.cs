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
            List<Department> deptList = _context.Departments.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();
          
            foreach (var dept in deptList)
            {
                SelectListItem sl = new SelectListItem();
                sl.Value = Convert.ToString(dept.DeptId);
                sl.Text = dept.DeptName;
                selectList.Add(sl);
            }

            SelectListItem samplesl = new SelectListItem();
            samplesl.Value = "0";
            samplesl.Text = "Please select department";
            samplesl.Selected = true;
            selectList.Add(samplesl);

            ViewBag.deptList = selectList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("Index");
        }

    }
}