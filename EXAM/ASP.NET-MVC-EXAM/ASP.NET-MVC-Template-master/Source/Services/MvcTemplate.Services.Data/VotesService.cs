namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class VotesService
    {
        private readonly IDbRepository<Vote> votes;

        public VotesService(IDbRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public Vote GetById(int id)
        {
            return this.votes.GetById(id);
        }

        public IQueryable<Vote> GetByIp(string ip)
        {
            return this.votes.All().Where(v => v.VoterIpAddress == ip);
        }
    }
}
