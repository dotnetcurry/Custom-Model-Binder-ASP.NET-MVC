using System.Linq;
using System.Web.Mvc;
using MVC_CustomModelBinder.Models;
using System.Xml.Serialization;

namespace MVC_CustomModelBinder.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationEntities ctx;
        public EmployeeController()
        {
            ctx = new ApplicationEntities();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var Emps = ctx.Employees.ToList();
            return View(Emps);
        }
        public ActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult Create(Employee Emp)
        {
            
            ctx.Employees.Add(Emp);
            ctx.SaveChanges(); 
            return View("Index") ;
        }

        //var empPostedData = new XmlSerializer(typeof(Employee));
        //var Emp = (Employee)empPostedData.Deserialize(HttpContext.Request.InputStream);
    }
}