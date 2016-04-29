namespace MvcTemplate.Web.ViewModels.Ideas
{
    using System.Collections.Generic;
    using MvcTemplate.Web.ViewModels.Home;

    public class IdeaDetailsViewModel
    {
        public IEnumerable<IdeaViewModel> Ideas { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
