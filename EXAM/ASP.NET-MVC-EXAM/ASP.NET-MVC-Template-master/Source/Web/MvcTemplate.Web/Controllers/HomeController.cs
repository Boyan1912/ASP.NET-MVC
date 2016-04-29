namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IIdeasService ideas;
        
        public HomeController(
            IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        public ActionResult Index()
        {
            var ideas = this.ideas.GetByVotesCount().Take(3).To<IdeaViewModel>().ToList();
            var viewModel = new IndexViewModel
            {
                Ideas = ideas,
            };

            return this.View(viewModel);
        }
    }
}
