using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private EventApplicationDb db = new EventApplicationDb();


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "You will be alble to find any type of even you desire on our website.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please, don't hesitate to contact us with any problem!";

            return View();
        }


        public ActionResult FindEvent()
        {
            return View();
        }


        public ActionResult LastMinuteDeal() {
            List<Event> events = GetLastMinuteDeals();
            if (events.Count > 0)
            {
                return PartialView("_LastMinuteDeal", events);
            }
            else {
                return PartialView("_NoResults");
            }
            
        }

        private List<Event> GetLastMinuteDeals()
        {
            var events = db.Events.Where(a => a.EndDate >= DateTime.Now && a.EndDate <= DbFunctions.AddDays(DateTime.Now, 2)).OrderBy(a => a.EndDate).Take(5).ToList();
            return events;
        }


        [AllowAnonymous]
        public ActionResult EventSearch(string q, string r)
        {

            List<Event> events = GetEvents(q, r);

            if (events.Count > 0)
            {

                return PartialView("_EventSearch", events);
            }
            else {

                return PartialView("_NoResults");

            }
        }

        private List<Event> GetEvents(string searchstring, string locationsearch)
        {
            string[] location = locationsearch.Split();
            string city;
            string state;

            if (location.Length > 1)
            {
                city = location[0].Replace(",","");
                state = location[1];

                return db.Events.Where(

                    a =>

                    (a.Title.Contains(searchstring) || a.EventType.Type.Contains(searchstring))

                    &&

                    (a.City.Contains(city) && a.State.Contains(state))

                     ).OrderBy(b => b.StartDate).ToList(); ;

            }
            else
            {
                city = locationsearch;
                state = locationsearch;

                return db.Events.Where( a =>

                (a.Title.Contains(searchstring) || a.EventType.Type.Contains(searchstring))

                &&

                (a.City.Contains(city) || a.State.Contains(state))

                ).OrderBy(b => b.StartDate).ToList(); ;
            }

        }

        
        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }



    }
}