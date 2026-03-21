using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingOutHobby.Models;

namespace WorkingOutHobby.Controllers
{
    public class ProgressController(WorkoutDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new ProgressViewModel
            {
                WorkoutTypes = await context.WorkoutTypes.ToListAsync(),
                History = await context.Workouts.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProgressViewModel progressViewModel)
        {
            if (ModelState.IsValid)
            {
                context.Workouts.Add(progressViewModel.Workout);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            } else
            {
                progressViewModel.WorkoutTypes = await context.WorkoutTypes.ToListAsync();
                return View(progressViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Workout? workout = await context.Workouts.FindAsync(id);
            if (workout != null)
            {
                context.Workouts.Remove(workout);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
