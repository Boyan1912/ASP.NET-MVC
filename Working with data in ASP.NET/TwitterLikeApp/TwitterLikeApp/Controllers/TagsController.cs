namespace TwitterLikeApp.Controllers
{
    using Data.UnitOfWork;
    using System.Linq;
    using System.Web.Mvc;

    public class TagsController : Controller
    {
        private const string DEFAULT_NAME = "#fail";
        private IUowData db;

        public TagsController(IUowData db)
        {
            this.db = db;
        }

        public TagsController()
        {
            this.db = new UowData();
        }

        [OutputCache(Duration = 15 * 60, VaryByParam="none")]
        public ActionResult Index()
        {
            var defaultResults = this.db.Twits.All()
                                               .Where(tw => tw.Text.IndexOf(DEFAULT_NAME) >= 0)
                                               .ToList();

            return View(defaultResults);
        }

        //public ActionResult All()
        //{
            
        //}


    }
}