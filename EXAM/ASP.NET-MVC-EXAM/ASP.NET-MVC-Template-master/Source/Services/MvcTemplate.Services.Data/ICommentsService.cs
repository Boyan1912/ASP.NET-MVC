namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Models;
    using System.Linq;

    public interface ICommentsService
    {

        Comment GetById(int id);

        IQueryable<Comment> GetByIp(string ip);

    }
}
