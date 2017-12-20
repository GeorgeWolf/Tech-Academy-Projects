using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using LearnVisualStudioAdmin.Models;
using LearnVisualStudioAdmin.Services;
using Microsoft.Security.Application;

namespace LearnVisualStudioAdmin.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Courses
        public ActionResult Index()
        {
            var courses = db.Courses.OrderBy(p => p.OrdinalPosition).ToList();
            return View(courses);

        }

        // GET: Admin/Courses/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            if (course.Lessons.Count > 0)
            {
                course.Lessons = course.Lessons.OrderBy(p => p.Number).ToList();
            }

            return View(course);
        }

        // GET: Admin/Courses/Create
        public ActionResult Create()
        {
            var dbCourse = db.Courses.OrderByDescending(p => p.OrdinalPosition).FirstOrDefault();

            var course = new Course() { Published = DateTime.Now };

            if (dbCourse != null)
            {
                course.OrdinalPosition = dbCourse.OrdinalPosition + 1;
            }
            else
            {
                course.OrdinalPosition = 1;
            }
            return View(course);
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                if (db.Courses.Any(p => p.Segment == course.Segment))
                {
                    ModelState.AddModelError("segment", "Please choose a unique segment name. That segment already exists.");
                    return View(course);
                }

                course.Id = Guid.NewGuid();
                course.Body = Sanitizer.GetSafeHtmlFragment(course.Body);
                course.Segment = course.Segment.ToLower();
                db.Courses.Add(course);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(course);
        }



        // GET: Admin/Courses/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                var query = db.Courses.Where(t => t.Segment == course.Segment).Select(p => new { Id = p.Id });
                foreach (var item in query)
                {
                    if (item.Id != course.Id)
                    {
                        ModelState.AddModelError("segment", "Segment name already exists.");
                        return View(course);
                    }

                }

                course.Body = Sanitizer.GetSafeHtmlFragment(course.Body);
                db.Entry(course).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Admin/Courses/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Course course = await db.Courses.FindAsync(id);
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
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
