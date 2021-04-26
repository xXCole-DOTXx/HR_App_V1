using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HR_App_V1.Models;

namespace HR_App_V1.Controllers
{
    public class Workers_CompensationController : Controller
    {
        private Human_ResourcesEntities db = new Human_ResourcesEntities();

        // GET: Workers_Compensation
        public ActionResult Index()
        {
            var workers_Compensation = db.Workers_Compensation.Include(w => w.Claim_Ruling_Type).Include(w => w.Employee).Include(w => w.WC_Type);
            return View(workers_Compensation.ToList());
        }

        // GET: Employees
        public ActionResult EmployeeSelect()
        {
            return View(db.Employees.ToList());
        }

        // GET: Workers_Compensation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers_Compensation workers_Compensation = db.Workers_Compensation.Find(id);
            if (workers_Compensation == null)
            {
                return HttpNotFound();
            }
            return View(workers_Compensation);
        }

        // GET: Workers_Compensation/Create
        public ActionResult Create(int? id)
        {
            System.Diagnostics.Debug.WriteLine("Employee full name: " + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            string fullName = employee.First_Name + " " + employee.Last_Name;
            System.Diagnostics.Debug.WriteLine("Employee full name: " + fullName);
            ViewBag.Claim_Ruling_TypeID = new SelectList(db.Claim_Ruling_Type, "ID", "Claim_Ruling_Type1");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "ID");
            ViewBag.Name = fullName;
            ViewBag.WC_TypeID = new SelectList(db.WC_Type, "ID", "WC_Type1");
            return View();
        }

        // POST: Workers_Compensation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,Org_Number,Division_District,WC_TypeID,Injury_Date,Claim_Number,Injury_Type,Body_Parts,Claim_Ruling_TypeID,Comments")] Workers_Compensation workers_Compensation)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("WC Type: " + workers_Compensation.WC_TypeID);
                System.Diagnostics.Debug.WriteLine("Claim ruling type: " + workers_Compensation.Claim_Ruling_TypeID);
                db.Workers_Compensation.Add(workers_Compensation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Claim_Ruling_TypeID = new SelectList(db.Claim_Ruling_Type, "ID", "Claim_Ruling_Type1", workers_Compensation.Claim_Ruling_TypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "First_Name", workers_Compensation.EmployeeID);
            ViewBag.WC_TypeID = new SelectList(db.WC_Type, "ID", "WC_Type1", workers_Compensation.WC_TypeID);
            return View(workers_Compensation);
        }

        // GET: Workers_Compensation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers_Compensation workers_Compensation = db.Workers_Compensation.Find(id);
            if (workers_Compensation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Claim_Ruling_TypeID = new SelectList(db.Claim_Ruling_Type, "ID", "Claim_Ruling_Type1", workers_Compensation.Claim_Ruling_TypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "First_Name", workers_Compensation.EmployeeID);
            ViewBag.WC_TypeID = new SelectList(db.WC_Type, "ID", "WC_Type1", workers_Compensation.WC_TypeID);
            return View(workers_Compensation);
        }

        // POST: Workers_Compensation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,Org_Number,Division_District,WC_TypeID,Injury_Date,Claim_Number,Injury_Type,Body_Parts,Job_Class,Tx_Date,EROI_Date,Tx_EROI_LAG,Claim_Ruling_TypeID,Claim_Ruling_Date,TTD_ONSET_Date,Restricted_RTW,Full_Duty_RTW,TTD_Award_Notice,RTW_Notice,Lost_Time,Lost_Time_Year,MVA,H_EQ,Tree_Brush,CTS,HL,OP,OD_NOC,Comments")] Workers_Compensation workers_Compensation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workers_Compensation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Claim_Ruling_TypeID = new SelectList(db.Claim_Ruling_Type, "ID", "Claim_Ruling_Type1", workers_Compensation.Claim_Ruling_TypeID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "First_Name", workers_Compensation.EmployeeID);
            ViewBag.WC_TypeID = new SelectList(db.WC_Type, "ID", "WC_Type1", workers_Compensation.WC_TypeID);
            return View(workers_Compensation);
        }

        // GET: Workers_Compensation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers_Compensation workers_Compensation = db.Workers_Compensation.Find(id);
            if (workers_Compensation == null)
            {
                return HttpNotFound();
            }
            return View(workers_Compensation);
        }

        // POST: Workers_Compensation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workers_Compensation workers_Compensation = db.Workers_Compensation.Find(id);
            db.Workers_Compensation.Remove(workers_Compensation);
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
