namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using MvcTemplate.Services.Data;
    using Data.Models;
    using ViewModels.Home;
    using Infrastructure.Mapping;
    public class IdeasController : BaseController
    {

        private readonly IIdeasService ideas;

        public IdeasController(
            IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        public ActionResult Details(string id)
        {
            var idea = this.ideas.GetById(id);
            var viewModel = this.Mapper.Map<IdeaViewModel>(idea);
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(Idea newIdea)
        {
            this.ideas.Add(newIdea);

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Search(string query)
        {

            var foundIdeas = this.ideas.FindBySearchTerm(query).To<IdeaViewModel>().ToList();
            
            return this.View(foundIdeas);
        }
    }
}
