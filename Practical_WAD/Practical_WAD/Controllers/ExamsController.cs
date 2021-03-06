using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practical_WAD.Context;
using Practical_WAD.Models;

namespace Practical_WAD.Controllers
{
    public class ExamsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Classroom).Include(e => e.ExamSubject).Include(e => e.Faculty);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "Id", "ClassName");
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "Id", "ExamName");
            ViewBag.FacultyID = new SelectList(db.Faculties, "Id", "Name");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,ExamDate,ExamDuration,ExamSubjectID,ClassroomID,FacultyID")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                exam.StatusID = 1;
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassroomID = new SelectList(db.Classrooms, "Id", "ClassName", exam.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "Id", "ExamName", exam.ExamSubjectID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "Id", "Name", exam.FacultyID);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "Id", "ClassName", exam.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "Id", "ExamName", exam.ExamSubjectID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "Id", "Name", exam.FacultyID);
            ViewBag.StatusID = new SelectList(db.Status, "Id", "statusName", exam.StatusID);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,ExamDate,ExamDuration,ExamSubjectID,ClassroomID,FacultyID,StatusID")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "Id", "ClassName", exam.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "Id", "ExamName", exam.ExamSubjectID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "Id", "Name", exam.FacultyID);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
