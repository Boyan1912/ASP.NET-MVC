namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Data.Common;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }

        public IQueryable<Comment> GetByIp(string ip)
        {
            return this.comments.All().Where(c => c.AuthorIp == ip);
        }
    }
}
