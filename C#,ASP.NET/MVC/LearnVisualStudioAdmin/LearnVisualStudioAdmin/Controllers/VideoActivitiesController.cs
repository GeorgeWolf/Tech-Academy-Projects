using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LearnVisualStudioAdmin.Models;
using LearnVisualStudioAdmin.Services;
using WebGrease.Css.Extensions;

namespace LearnVisualStudioAdmin.Controllers
{
    [Authorize]
    public class VideoActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/VideoActivity/Create
        public async Task<ActionResult> Create(Guid lessonId)
        {
            var dbVideoActivity =
                db.VideoActivity.OrderByDescending(p => p.OrdinalPosition).FirstOrDefault(t => t.LessonId == lessonId);

            var videoActionEditViewModel = new VideoActionEditViewModel();
            var videoActivity = new VideoActivity() { LessonId = lessonId, Published = DateTime.UtcNow };

            if (dbVideoActivity != null)
            {
                videoActivity.OrdinalPosition = dbVideoActivity.OrdinalPosition + 1;
            }
            else
            {
                videoActivity.OrdinalPosition = 1;
            }

            videoActionEditViewModel.VideoActivity = videoActivity;
            await PopulateActivityRoleDropdowns(videoActionEditViewModel);

            return View(videoActionEditViewModel);
        }

        private async Task PopulateActivityRoleDropdowns(VideoActionEditViewModel videoActionEditViewModel)
        {
            var roles = await CachedRolesService.GetRoles();
            var identityRoles = roles.Select(p => new { Id = p.Id, Name = p.Name }).ToArray();

            // Edit Scenario:
            if (videoActionEditViewModel.SelectedViewsItemIds != null || videoActionEditViewModel.VideoActivity.Id != Guid.Empty)
            {
                if (videoActionEditViewModel.SelectedViewsItemIds == null)
                {
                    var selectedViewsItemIds =
                        videoActionEditViewModel.VideoActivity.ActivityRoles.Where(q => q.Permission == PermissionType.View)
                            .Select(p => p.RoleId.ToString())
                            .ToArray();
                    videoActionEditViewModel.SelectedViewsItemIds = selectedViewsItemIds;
                }

                if (videoActionEditViewModel.SelectedDownloadsItemIds == null)
                {
                    var selectedDownloadsItemIds =
                        videoActionEditViewModel.VideoActivity.ActivityRoles.Where(
                            q => q.Permission == PermissionType.Download).Select(p => p.RoleId.ToString()).ToArray();
                    videoActionEditViewModel.SelectedDownloadsItemIds = selectedDownloadsItemIds;
                }

                if (videoActionEditViewModel.SelectedCommentsItemIds == null)
                {
                    var selectedCommentsItemIds =
                        videoActionEditViewModel.VideoActivity.ActivityRoles.Where(
                            q => q.Permission == PermissionType.Comment).Select(p => p.RoleId.ToString()).ToArray();

                    videoActionEditViewModel.SelectedCommentsItemIds = selectedCommentsItemIds;
                }

                videoActionEditViewModel.ViewsItems = new MultiSelectList(identityRoles, "Id", "Name",
                    videoActionEditViewModel.SelectedViewsItemIds);
                videoActionEditViewModel.DownloadsItems = new MultiSelectList(identityRoles, "Id", "Name",
                    videoActionEditViewModel.SelectedDownloadsItemIds);
                videoActionEditViewModel.CommentsItems = new MultiSelectList(identityRoles, "Id", "Name",
                    videoActionEditViewModel.SelectedCommentsItemIds);

            }
            else
            {
                // Create Scenario
                // Pre-fill selected ids
                var oneYear = roles.First(p => p.Name == "1Year").Id;
                var lifetime = roles.First(p => p.Name == "Lifetime").Id;
                string[] initializedViewsItemIds = { oneYear, lifetime };
                string[] initializedDownloadItemIds = { lifetime };
                string[] initializedCommentsItemIds = { lifetime };

                videoActionEditViewModel.ViewsItems = new MultiSelectList(identityRoles, "Id", "Name",
                    initializedViewsItemIds);
                videoActionEditViewModel.DownloadsItems = new MultiSelectList(identityRoles, "Id", "Name",
                    initializedDownloadItemIds);
                videoActionEditViewModel.CommentsItems = new MultiSelectList(identityRoles, "Id", "Name",
                    initializedCommentsItemIds);
            }
        }

        // POST: Admin/VideoActivity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VideoActionEditViewModel videoActionEditViewModel)
        {
            if (ModelState.IsValid)
            {
                if (db.VideoActivity.Any(p => p.Segment == videoActionEditViewModel.VideoActivity.Segment))
                {
                    ModelState.AddModelError("segment", "Please choose a unique segment name. That segment already exists.");
                }
            }

            if (!ModelState.IsValid)
            {
                await PopulateActivityRoleDropdowns(videoActionEditViewModel);
                return View(videoActionEditViewModel);
            }

            var videoActivity = videoActionEditViewModel.VideoActivity;
            videoActivity.Id = Guid.NewGuid();

            CreateActivityRoles(videoActionEditViewModel, videoActivity);

            db.VideoActivity.Add(videoActivity);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Lessons", new { Id = videoActivity.LessonId });
        }

        // GET: Admin/VideoActivity/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var videoActionEditViewModel = new VideoActionEditViewModel();

            VideoActivity videoActivity = await db.VideoActivity.FindAsync(id);
            if (videoActivity == null)
            {
                return HttpNotFound();
            }
            var activityRoles = videoActivity.ActivityRoles.ToList();

            videoActionEditViewModel.VideoActivity = videoActivity;
            await PopulateActivityRoleDropdowns(videoActionEditViewModel);

            return View(videoActionEditViewModel);
        }

        // POST: Admin/VideoActivity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // TODO: Add Bind statement to avoid overposting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VideoActionEditViewModel videoActionEditViewModel)
        {
            await PopulateActivityRoleDropdowns(videoActionEditViewModel);

            if (!ModelState.IsValid)
            {
                return View(videoActionEditViewModel);
            }

            var videoActivity = videoActionEditViewModel.VideoActivity;
            db.Entry(videoActivity).State = EntityState.Modified;



            var query = db.VideoActivity.Where(t => t.Segment == videoActivity.Segment).Select(p => new {Id = p.Id});
            foreach (var item in query)
            {
                if (item.Id != videoActivity.Id)
                {
                    ModelState.AddModelError("VideoActivity.Segment", "Segment name already exists.");
                    break;
                }
                    
            }

            if (!ModelState.IsValid)
            {
                return View(videoActionEditViewModel);
            }


            //******************************************************************
            // Updating the ActivityRoles
            //******************************************************************
            // I'm sure there's a better way to do this, but I'm going to handle 
            // this with brute force.  I'm going to remove all the current
            // ActivityRoles, then insert whatever was submitted in the Edit Post.
            // Force ActivityRoles to be loaded from the database
            // so that I can delete them all.
            var temp = db.VideoActivity.Include(p => p.ActivityRoles).FirstOrDefault(q => q.Id == videoActivity.Id);

            for (int i = temp.ActivityRoles.Count - 1; i > -1; i--)
            {
                temp.ActivityRoles.Remove(videoActivity.ActivityRoles.ElementAt(i));
            }

            CreateActivityRoles(videoActionEditViewModel, videoActivity);
            //******************************************************************

            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Lessons", new { Id = videoActivity.LessonId });
        }

        // POST: Admin/VideoActivity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            VideoActivity videoActivity = await db.VideoActivity.FindAsync(id);
            db.VideoActivity.Remove(videoActivity);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Lessons", new { Id = videoActivity.LessonId });
        }


        public void CreateActivityRoles(VideoActionEditViewModel videoActionEditViewModel, VideoActivity videoActivity)
        {
            videoActionEditViewModel.SelectedViewsItemIds.ForEach(
                 p => videoActivity.ActivityRoles.Add(new ActivityRole
                 {
                     Id = Guid.NewGuid(),
                     RoleId = p,
                     Permission = PermissionType.View
                 }));

            videoActionEditViewModel.SelectedDownloadsItemIds.ForEach(
                p => videoActivity.ActivityRoles.Add(new ActivityRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = p,
                    Permission = PermissionType.Download
                }));

            videoActionEditViewModel.SelectedCommentsItemIds.ForEach(
                p => videoActivity.ActivityRoles.Add(new ActivityRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = p,
                    Permission = PermissionType.Comment
                }));
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