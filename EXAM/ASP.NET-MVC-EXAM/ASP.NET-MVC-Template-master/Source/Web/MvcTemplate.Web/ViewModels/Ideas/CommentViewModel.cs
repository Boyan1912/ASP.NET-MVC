namespace MvcTemplate.Web.ViewModels.Ideas
{
    using System;
    using Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {

        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
