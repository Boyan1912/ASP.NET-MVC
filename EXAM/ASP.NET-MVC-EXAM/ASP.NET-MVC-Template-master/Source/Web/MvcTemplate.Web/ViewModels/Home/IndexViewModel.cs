namespace MvcTemplate.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IdeaViewModel> Ideas { get; set; }

        //public IEnumerable<VoteViewModel> Votes { get; set; }

        //public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
