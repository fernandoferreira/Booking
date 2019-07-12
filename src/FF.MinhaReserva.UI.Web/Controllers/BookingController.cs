using DomainValidation.Validation;
using FF.MinhaReserva.Application.Interfaces;
using FF.MinhaReserva.Application.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FF.MinhaReserva.UI.Web.Controllers
{
    public class BookingController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IBookingAppService _bookingAppService;

        public BookingController(IBookingAppService bookingAppService)
        {
            _bookingAppService = bookingAppService;
        }

        // GET: Booking
        public ActionResult Index()
        {
            //return View(_bookingAppService.GetBystatus().ToList());
            return null;
        }

        // GET: Booking/Details/5
        //public ActionResult Details(Guid id)
        //{

        //    //BookingViewModel bookingViewModel =_bookingAppService.GetByRoom(id)
        //    //if (bookingViewModel == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(bookingViewModel);
        //}

        //GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
                return View(bookingViewModel);
            else
            {
                bookingViewModel = _bookingAppService.Add(bookingViewModel);
                if (bookingViewModel.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                AddErrorIntoModelState(bookingViewModel.ValidationResult);

                return View(bookingViewModel);
            }
        }

        private void AddErrorIntoModelState(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
        }

        // GET: Booking/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
        //    if (bookingViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookingViewModel);
        //}

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,RoomId,AttendeeId,BookingDate,StartDate,EndtDate,Comment")] BookingViewModel bookingViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(bookingViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(bookingViewModel);
        //}

        // GET: Booking/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
        //    if (bookingViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookingViewModel);
        //}

        // POST: Booking/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    BookingViewModel bookingViewModel = db.BookingViewModels.Find(id);
        //    db.BookingViewModels.Remove(bookingViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
