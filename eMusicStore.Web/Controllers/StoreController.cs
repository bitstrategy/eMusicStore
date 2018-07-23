using eMusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMusicStore.Web.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreEntities _storeDB = new MusicStoreEntities();
        // GET: Store
        public ActionResult Index()
        {
            var genres = _storeDB.Genres.ToList();
            return View(genres);
        }

        public ActionResult Browse(string genre)
        {
            ViewBag.Genre = genre;
            var albums = _storeDB.Albums.Where(a => a.Genre.Name == genre).ToList();
            return View(albums);
        }

        public ActionResult Details(int id)
        {
            var album = _storeDB.Albums.Find(id);
            return View(album);
        }
    }
}
