using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    public class EventOrganizerController : Controller
    {
        private EventApplicationDb db = new EventApplicationDb();

        // GET: EventOrganizer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Events/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "Type");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventTypeId,Title,Description,StartDate,EndDate,MaxTickets,AvailableTickets,Organizer,OrganizerContactInfo,City,State")] Event @event)
        {
            if (@event.StartDate > DateTime.Now )
            {

                if(@event.StartDate < @event.EndDate)
                {

                    if (ModelState.IsValid)
                    {
                        db.Events.Add(@event);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home", null);
                    }

                }

            }

            if (@event.StartDate < DateTime.Now)
            {
                ViewBag.Message = "Events must start in the future.";

            }


            if (@event.StartDate > @event.EndDate)
            {
                ViewBag.EndMessage = "Events must end after they start.";

            }



            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "Type", @event.EventTypeId);


            return View(@event);
        }


        // GET: EventTypes/Create
        public ActionResult CreateEventType()
        {
            return View();
        }

        // POST: EventTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEventType([Bind(Include = "EventTypeId,Type")] EventType eventType)
        {
            if (ModelState.IsValid)
            {
                db.EventTypes.Add(eventType);
                db.SaveChanges();
                return RedirectToAction("Create", "EventOrganizer");
            }

            return View(eventType);
        }
    }
}