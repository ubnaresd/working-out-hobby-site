using Microsoft.AspNetCore.Mvc;

public class WorkoutController : Controller
{
    public IActionResult Routines()
    {
        return View();
    }

    public IActionResult Equipment()
    {
        return View();
    }
}