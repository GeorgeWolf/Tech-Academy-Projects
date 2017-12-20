using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LearnVisualStudioAdmin.Models;

namespace LearnVisualStudioAdmin.Controllers
{
    [Authorize]
    public class LessonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Lessons/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = await db.Lessons.FindAsync(id);

            if (lesson == null)
            {
                return HttpNotFound();
            }


            if (lesson.Activities == null)
                lesson.Activities = new List<Activity>();
            else
            {
                // Unfortunately, there's no easy way to order navigation
                // properties.  So, I'm hacking this ...
                lesson.Activities = lesson.Activities.OrderBy(p => p.OrdinalPosition).ToList();
            }

            return View(lesson);
        }

        // GET: Admin/Lessons/Create
        public async Task<ActionResult> Create(Guid courseId)
        {
            try
            {
                // TODO: Project just the properties I need to reduce the chatter.
                var course = await db.Courses.FindAsync(courseId);
                ViewBag.CourseId = course.Id;
                ViewBag.CourseName = course.AdminFriendlyName;
                return View();
            }
            catch (Exception ex)
            {
                Response.Write(ex.InnerException.Message);
                throw;
            }
        }

        // POST: Admin/Lessons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                lesson.Id = Guid.NewGuid();
                db.Lessons.Add(lesson);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Courses", new { Id = lesson.CourseId });
            }

            return View(lesson);
        }

        // GET: Admin/Lessons/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = await db.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Admin/Lessons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Courses", new { Id = lesson.CourseId });
            }
            return View(lesson);
        }

        // GET: Admin/Lessons/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = await db.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Admin/Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Lesson lesson = await db.Lessons.FindAsync(id);
            db.Lessons.Remove(lesson);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Courses", new { Id = lesson.CourseId });
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