using Microsoft.AspNetCore.Mvc;
using NutritionWebsite.data;
using NutritionWebsite.Models;

namespace NutritionWebsite.Controllers
{
    public class DiaryEntryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DiaryEntryController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            List<DiaryEntry> entries = _db.DiaryEntries.ToList();
            return View(entries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        { 
            _db.DiaryEntries.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "DiaryEntry");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry diaryEntry = _db.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            _db.DiaryEntries.Remove(diaryEntry);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            _db.DiaryEntries.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
