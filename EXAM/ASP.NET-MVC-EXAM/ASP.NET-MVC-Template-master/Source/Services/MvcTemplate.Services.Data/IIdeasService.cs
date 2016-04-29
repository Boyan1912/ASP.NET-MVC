namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Models;
    using System.Linq;

    public interface IIdeasService
    {

        Idea GetById(string id);

        IQueryable<Idea> GetByIp(string ip);

        IQueryable<Idea> GetByDateTime();

        IQueryable<Idea> GetByVotesCount();

        void Add(Idea newIdea);

        IQueryable<Idea> FindInTitle(string query);

        IQueryable<Idea> FindInDescription(string query);

        IQueryable<Idea> FindBySearchTerm(string query);
    }
}
