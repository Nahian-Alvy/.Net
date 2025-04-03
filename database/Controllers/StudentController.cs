using database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace database.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            var db = new StudentEntities2();
            var data = db.students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(student student)
        {
            var db = new StudentEntities2();
            db.students.Add(student);
            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Student added successfully";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Failed to add student";
            return View(student);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new StudentEntities2();
            var student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(student student)
        {
            var db = new StudentEntities2();
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Student updated successfully";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Failed to update student";
            return View(student);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new StudentEntities2();
            var student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var db = new StudentEntities2();
            var student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            db.students.Remove(student);
            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Student deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Failed to delete student";
            return View(student);



        }
    }
}