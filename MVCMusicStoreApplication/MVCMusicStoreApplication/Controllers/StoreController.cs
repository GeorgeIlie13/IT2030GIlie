
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        private MVCMusicStoreDB db = new MVCMusicStoreDB();
        // GET: Store
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var results = db.Albums.Where(a => a.GenreId == id);
            return View(results.ToList());
        }

        [HttpGet]
        public ActionResult Browse()
        {
            var albums = db.Genres;
            return View(albums.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var album = db.Albums.Find(id);
            return View(album);
        }
    }
}