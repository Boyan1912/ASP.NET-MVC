namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using Web;

    public class IdeasService : IIdeasService
    {
        private readonly IDbRepository<Idea> ideas;
        //private readonly IIdentifierProvider identifierProvider;

        public IdeasService(IDbRepository<Idea> ideas)
        {
            this.ideas = ideas;
            //this.identifierProvider = identifierProvider;
        }

        public Idea GetById(string id)
        {
            // TO DO Check for valid id
            var intId = int.Parse(id);

            var idea = this.ideas.GetById(intId);
            return idea;
        }

        public IQueryable<Idea> GetByIp(string ip)
        {
            return this.ideas.All().Where(i => i.AuthorIpAddress == ip);
        }

        public IQueryable<Idea> GetByDateTime()
        {
            return this.ideas.All().OrderByDescending(i => i.CreatedOn);
        }

        public IQueryable<Idea> GetByVotesCount()
        {
            return this.ideas.All().OrderByDescending(i => i.Votes.Count);
        }

        public void Add(Idea newIdea)
        {
            this.ideas.Add(newIdea);
        }

        public IQueryable<Idea> FindInTitle(string query)
        {
            return this.ideas.All()
                        .Where(i => i.Title.Contains(query));
        }

        public IQueryable<Idea> FindInDescription(string query)
        {
            return this.ideas.All()
                        .Where(i => i.Description.Contains(query));
        }

        public IQueryable<Idea> FindBySearchTerm (string query)
        {
            return this.ideas.All()
                        .Where(i => i.Title.Contains(query) || i.Description.Contains(query));
        }
    }
}
