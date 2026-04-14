using DoctorManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoctorManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbcontext _db;
        public HomeController()
        {
            _db = new ApplicationDbcontext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult BookAppointment()
        //{
        //    var doctors = _db.Doctors.AsQueryable();
        //    doctors = doctors.Skip(0)
        //        .Take(6);

        //    return View(doctors.AsEnumerable());
        //}
        public IActionResult BookAppointment(string? Name = null)
        {
            var doctors = _db.Doctors.AsQueryable();
            if (Name is not null)
            {
                doctors = doctors.Where(e => e.Name.Contains(Name));
            }

            return View(doctors.AsEnumerable());
        }

        [HttpGet]
        public IActionResult CompleteAppointment(int id)
        {
            var ressult = _db.Doctors.SingleOrDefault(e => e.Id == id);
            return View(ressult);
        }

        [HttpPost]
        public IActionResult CompleteAppointment(string Name, DateTime DateBook, TimeOnly TimeBook, int DoctorID)
        {

            var doctor = _db.Doctors.Include(d => d.Books).FirstOrDefault(e => e.Id == DoctorID);

            if (doctor == null) return NotFound();


            bool isTaken = doctor.Books.Any(b => b.TimeBook == TimeBook);

            if (isTaken)
            {
                TempData["ErrorMessage"] = "This time slot is already reserved. Please choose another.";
                // Redirect back to the GET action to show the error
                //return RedirectToAction("CompleteAppointment", new { id = DoctorID });
                return RedirectToAction(nameof(CompleteAppointment), new { id = DoctorID });
            }


            var newBook = new Models.BookAppointment
            {
                Name = Name,
                DateBook = DateBook,
                TimeBook = TimeBook,
                DoctorID = DoctorID
            };

            _db.bookAppointments.Add(newBook);
            _db.SaveChanges();

            // 4. Set the success message
            TempData["SuccessMessage"] = "Appointment successfully booked!";

            return RedirectToAction(nameof(CompleteAppointment), new { id = DoctorID });
        }
        //[HttpPost]
        //public IActionResult CompleteAppointment(string Name, DateTime DateBook, TimeOnly TimeBook, int DoctorID)
        //{

        //    bool book = true;
        //    _db.bookAppointments.Add(new Models.BookAppointment
        //    {
        //        Name = Name,
        //        DateBook = DateBook,
        //        TimeBook = TimeBook,
        //        DoctorID = DoctorID
        //    });
        //    var check = _db.Doctors.FirstOrDefault(e => e.Id == DoctorID);
        //    foreach (var item in check.Books)
        //    {

        //        if (item.TimeBook == TimeBook)
        //        {
        //            book = false; break;
        //        }
        //    }
        //    if (book)
        //    {
        //        _db.SaveChanges();
        //    }

        //    var doctor = _db.Doctors.FirstOrDefault(e => e.Id == DoctorID);
        //    //var book =_db.bookAppointments.Where(e=>e.DoctorID== DoctorID).AsEnumerable();
        //    return RedirectToAction(nameof(ReservationsManagement));
        //    //return View(nameof(CompleteAppointment));
        //}
        public IActionResult ReservationsManagement()
        {
            var result = _db.bookAppointments.AsQueryable();


            return View(result.AsEnumerable());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
