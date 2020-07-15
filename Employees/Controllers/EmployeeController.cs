using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.Database.Tables;
using Employees.Extensions;
using Employees.Services;

namespace Employees.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        IEmployeeImportService _importService;

        /// <summary>
        /// 
        /// </summary>
        IEmployeeService _employeeService;

        /// <summary>
        /// 
        /// </summary>
        public EmployeeController(IEmployeeImportService importService, IEmployeeService employeeService)
        {
            _importService = importService;
            _employeeService = employeeService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData()
        {
            var empList = _employeeService.Read();
            return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Import()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    var importResult = files.ImportFilesToDatabase(_importService, _employeeService);

                    return Json(new { success = true, message = importResult },
                                JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { success = false, message = "No files chosen" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddOrEdit(Guid? id)
        {
            if (id == Guid.Empty || id == null)
                return View(new Employee());
            else
                return View(_employeeService.Read(id ?? Guid.Empty) ?? new Employee());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            _employeeService.AddOrEdit(emp);
            return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _employeeService.Remove(id);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}