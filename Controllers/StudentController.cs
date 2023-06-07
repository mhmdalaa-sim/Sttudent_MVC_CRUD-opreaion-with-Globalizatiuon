using Microsoft.AspNetCore.Mvc;
using StudentTask.Models;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using MVCTASK.Data;
using MVCTASK.Models;

namespace StudentTask.Controllers
{
    public class StudentController : BaseController
    {

        private readonly MvctaskContext _context;

        public StudentController(MvctaskContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Index(string searchString, int pg = 1)

        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-EG");

            IEnumerable<Student> students = _context.Students.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(d => d.Sname == searchString);
            }

            int rescCount = students.Count();

            var pager = new Pager(rescCount, pg, 5);

            int recSkip = (pg - 1) * 5;

            var data = students.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(student);

        }

        [HttpPost]

        public IActionResult Edit(Student student)
        {
            _context.Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            Student student = _context.Students.Where(s => s.Id == id).FirstOrDefault();

            return View(student);
        }

        [HttpPost]

        public IActionResult Delete(Student student)
        {
            _context.Attach(student);
            _context.Entry(student).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sname,Gender,Dateofbirth,City,IsEnrolled")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }


        public IActionResult Arabic()
        {
            HttpContext.Session.SetString("Lang", "ar-EG");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult English()
        {
            HttpContext.Session.SetString("Lang", "en-US");
            return RedirectToAction(nameof(Index));
        }




    }
}