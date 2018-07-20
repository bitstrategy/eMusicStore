using eMusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMusicStore.Web.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreEntities _storeDB = new MusicStoreEntities();

        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = _storeDB.Albums.Include("Genre").Include("Artist")
                .OrderBy(a => a.Price).ToList();
            return View(albums);
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int id)
        {
            var album = _storeDB.Albums.Find(id);
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(_storeDB.Artists, "ArtistId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _storeDB.Albums.Add(album);
                _storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_storeDB.Artists, "ArtistId", "Name", album.ArtistId);

            return View(album);

        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            var album = _storeDB.Albums.Find(id);
            ViewBag.GenreId = new SelectList(_storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_storeDB.Artists, "ArtistId", "Name", album.ArtistId);

            return View(album);
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
                _storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_storeDB.Artists, "ArtistId", "Name", album.ArtistId);

            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            var album = _storeDB.Albums.Find(id);
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var album = _storeDB.Albums.Find(id);
            _storeDB.Albums.Remove(album);
            _storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
