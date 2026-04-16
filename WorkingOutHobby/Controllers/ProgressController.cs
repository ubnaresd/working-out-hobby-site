using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkingOutHobby.Models;

namespace WorkingOutHobby.Controllers
{
    [Authorize]
    public class ProgressController(WorkoutDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var model = new ProgressViewModel
            {
                WorkoutTypes = await context.WorkoutTypes.ToListAsync(),
                History = await context.Workouts
                    .Include(w => w.WorkoutType)
                    .Where(w => w.UserId == userId)
                    .OrderByDescending(w => w.Date)
                    .ToListAsync(),
                Workout = new Workout { Date = DateTime.Today }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProgressViewModel progressViewModel)
        {
            var userId = GetUserId();

            progressViewModel.Workout.UserId = userId;

            ModelState.Remove("Workout.UserId");
            ModelState.Remove("Workout.WorkoutType");

            if (ModelState.IsValid)
            {
                context.Workouts.Add(progressViewModel.Workout);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            progressViewModel.WorkoutTypes = await context.WorkoutTypes.ToListAsync();
            progressViewModel.History = await context.Workouts
                .Where(w => w.UserId == userId)
                .ToListAsync();

            return View("Index", progressViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();

            var workout = await context.Workouts
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == userId);

            if (workout != null)
            {
                context.Workouts.Remove(workout);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private Guid GetUserId()
        {
            var idString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(idString, out var guid) ? guid : Guid.Empty;
        }
    }
}