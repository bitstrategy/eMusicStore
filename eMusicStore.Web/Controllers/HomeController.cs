using eMusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreEntities _storeDB = new MusicStoreEntities();

        // GET: Home
        public ActionResult Index()
        {
            //var genres = _storeDB.Genres.ToList();
            //return View(genres);
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }

        public ActionResult Test()
        {
            return View("Error");
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            return _storeDB.Albums.OrderByDescending(a => a.OrderDetails.Count()).Take(count).ToList();
        }
    }
}