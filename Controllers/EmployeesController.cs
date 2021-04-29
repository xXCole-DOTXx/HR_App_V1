using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HR_App_V1.Models;
using PagedList;

namespace HR_App_V1.Controllers
{
    public class EmployeesController : Controller
    {
        private Human_ResourcesEntities db = new Human_ResourcesEntities();

        // GET: Employees
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.lNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
            ViewBag.fNameSortParm = sortOrder == "fName" ? "fName_desc" : "fName";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = from e in db.Employees
                           select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Last_Name.Contains(searchString)
                                       || s.First_Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "lname_desc":
                    employees = employees.OrderByDescending(e => e.Last_Name);
                    break;
                case "fName":
                    employees = employees.OrderBy(e => e.First_Name);
                    break;
                case "fName_desc":
                    employees = employees.OrderByDescending(e => e.First_Name);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Last_Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create(int? from)
        {
            
            if (from == 1)
            {
                ViewBag.RedirectTo = 1;
            }
            
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name")] Employee employee, int? RedirectTo)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                //If the page you came from was creating a new Injury form
                if(RedirectTo == 1)
                {
                    //Get the ID of the Employee you just created so you can pass it to the Injury Form Create page
                    int? intIdt = db.Employees.Max(u => (int?)u.ID);
                    return RedirectToAction("Create", "Workers_Compensation", new { id = intIdt });
                }
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
