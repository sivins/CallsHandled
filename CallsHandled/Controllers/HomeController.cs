using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CallsHandled.Models;
using System.Diagnostics;

namespace CallsHandled.Controllers
{
    public class HomeController : Controller
    {
        private CallContext db = new CallContext();

        private DateTime TimerStart { get; set; }
        private DateTime TimerStop { get; set; }

        /*
        private SelectList ResolutionList = new SelectList(new List<SelectListItem>() { 
                new SelectListItem() { Value="Resolved", Text = "Resolved" },
                new SelectListItem() { Value="Referred", Text = "Refer to IT/Vendor" },
                new SelectListItem() { Value="Ticket", Text = "Ticket" },
                new SelectListItem() { Value="Follow-Up", Text = "Follow-Up" },
                new SelectListItem() { Value="Escalated", Text = "Escalate to Supervisor" },
                new SelectListItem() { Value="Dropped", Text = "Call Dropped" }
            });
*/

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Calls.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = db.Calls.Find(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            Timer.TimerStart = DateTime.Now;
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Seconds,Resolution,Flag,Details,Timestamp")] Call call)
        {
            Timer.TimerStop = DateTime.Now;
            TimeSpan difference = Timer.TimerStop - Timer.TimerStart;
            call.Seconds = difference.Seconds;
            call.Timestamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Calls.Add(call);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(call);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = db.Calls.Find(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Seconds,Resolution,Flag,Details,Timestamp")] Call call)
        {
            if (ModelState.IsValid)
            {
                db.Entry(call).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(call);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = db.Calls.Find(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Call call = db.Calls.Find(id);
            db.Calls.Remove(call);
            db.SaveChanges();
            return RedirectToAction("Index");
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
