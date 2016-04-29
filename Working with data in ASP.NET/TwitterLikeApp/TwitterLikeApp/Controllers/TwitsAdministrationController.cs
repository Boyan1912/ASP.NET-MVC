namespace TwitterLikeApp.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.Security;
    using TwitterLikeApp.Data.UnitOfWork;
    using TwitterLikeApp.Models;

    public class TwitsAdministrationController : Controller
    {
        private IUowData db;
        
        public TwitsAdministrationController(IUowData db)
        {
            this.db = db;
        }

        public TwitsAdministrationController()
        {
            this.db = new UowData();
        }

        // GET: TwitsAdministration
        public ActionResult Index()
        {
            var twits = db.Twits.All();
            return View(twits.ToList());
        }

        public ActionResult UserTwits()
        {
            string currentUserId = this.User.Identity.GetUserId();
            var twits = db.Twits.All()
                           .Where(x => x.AuthorId == currentUserId)
                           .ToList();

            return View("Index", twits);
        }


        // GET: TwitsAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Twit twit = db.Twits.GetById((int)id);

            if (twit == null)
            {
                return HttpNotFound();
            }
            return View(twit);
        }

        // GET: TwitsAdministration/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users.All(), "Id", "Email");
            return View();
        }

        // POST: TwitsAdministration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles ="Admin", Users ="pesho@pesho.com")]
        public ActionResult Create([Bind(Include = "Id,Text,AuthorId")] Twit twit)
        {
            if (ModelState.IsValid)
            {
                db.Twits.Add(twit);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users.All().ToList(), "Id", "Email", twit.AuthorId);
            return View(twit);
        }

        // GET: TwitsAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Twit twit = db.Twits.GetById((int)id);

            if (twit == null)
            {
                return HttpNotFound();
            }

            ViewBag.AuthorId = new SelectList(db.Users.All().ToList(), "Id", "Email", twit.AuthorId);
            return View(twit);
        }

        // POST: TwitsAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,AuthorId")] Twit twit)
        {
            if (ModelState.IsValid)
            {
                db.Twits.Add(twit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users.All(), "Id", "Email", twit.AuthorId);
            return View(twit);
        }

        // GET: TwitsAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.GetById((int)id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            return View(twit);
        }

        // POST: TwitsAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Twit twit = db.Twits.GetById(id);
            db.Twits.Delete(twit);
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
