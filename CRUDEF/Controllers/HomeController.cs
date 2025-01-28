using CRUDEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEF.Controllers
{
	public class HomeController : Controller
	{
		private SchoolContext schoolContext;
		public HomeController(SchoolContext sc)
		{
			schoolContext = sc;
		}

		public IActionResult Index()
		{
			return View(schoolContext.Teacher);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Teacher teacher)
		{
			if (ModelState.IsValid)
			{
				schoolContext.Teacher.Add(teacher);
				schoolContext.SaveChanges();
				return RedirectToAction("Index");
			}
			else
				return View();
		}

        public IActionResult Update(int id)
        {
            return View(schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Teacher teacher)
        {
            schoolContext.Teacher.Update(teacher);
            schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var teacher = schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault();
			schoolContext.Teacher.Remove(teacher);
			schoolContext.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}