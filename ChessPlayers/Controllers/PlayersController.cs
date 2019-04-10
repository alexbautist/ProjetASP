using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChessPlayers.Models;

namespace ChessPlayers.Controllers
{
    public class PlayersController : Controller
    {
        private PlayerDBContext db = new PlayerDBContext();

        // GET: Players
        public ActionResult Index(String sortOrder)
        {
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            var players = from s in db.Players
                           select s;
            switch (sortOrder)
            {
                case "Rating":
                    players = players.OrderBy(s => s.Rating);
                    break;
                case "rating_desc":
                    players = players.OrderByDescending(s => s.Rating);
                    break;
                case "Date":
                    players = players.OrderBy(s => s.Birth);
                    break;
                case "date_desc":
                    players = players.OrderByDescending(s => s.Birth);
                    break;
                case "Name":
                    players = players.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    players = players.OrderByDescending(s => s.Name);
                    break;
                default:
                    players = players.OrderByDescending(s => s.Rating);
                    break;
            }
            return View("Index",players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Add()
        {
            return View("Add");
        }

        // POST: Players/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,Name,Birth,Country,Rating")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Birth,Country,Rating")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View("Delete",player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
