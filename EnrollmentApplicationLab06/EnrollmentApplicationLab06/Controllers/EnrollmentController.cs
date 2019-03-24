using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnrollmentApplicationLab06.Models;

namespace EnrollmentApplicationLab06.Controllers
{
    public class EnrollmentController : Controller
    {
        private EnrollmentDB db = new EnrollmentDB();

        public ActionResult StudentSearch(string q)
        {
            var students = GetStudents(q);
            if (students.Any())
            {
                return PartialView("_StudentSearch", students);
            }
            return PartialView("_NoResultsFound");
        }

        private List<Student> GetStudents(string searchString)
        {
            return db.Students
                .Where(a => a.StudentFirstName.Contains(searchString) || a.StudentLastName.Contains(searchString))
                .OrderBy(a => a.StudentLastName)
                .ToList();
        }

        public ActionResult CourseSearch(string q)
        {
            var courses = GetCourses(q);
            if (courses.Any())
            {
                return PartialView("_CourseSearch", courses);
            }
            return PartialView("_NoResultsFound");
        }

        private List<Course> GetCourses(string searchString)
        {
            return db.Courses
                .Where(a => a.CourseTitle.Contains(searchString) || a.CourseDescription.Contains(searchString))
                .OrderBy(a => a.CourseTitle)
                .ToList();
        }

        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseTitle");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentLastName");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,StudentID,CourseID,Grade,StudentObject,CourseObject,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear,Notes")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseTitle", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentLastName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseTitle", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentLastName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,StudentID,CourseID,Grade,StudentObject,CourseObject,IsActive,AssignedCampus,EnrollmentSemester,EnrollmentYear,Notes")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseTitle", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentLastName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
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
