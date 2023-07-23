using DatabaseFirstApproachEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseFirstApproachEF.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(student s)
        {
            if(ModelState.IsValid == true)
            {
                db.students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Inserted!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Data not Inserted!!')</script>";
                }
            }
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["EditMessage"] = "<script>alert('Data Updated!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["EditMessage"] = "<script>alert('Data not Updated!!')</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var Deletedrow = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(Deletedrow);
        }
        [HttpPost]
        public ActionResult Delete(student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data Deleted!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Data not Deleted!!')</script>";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }
    }
}