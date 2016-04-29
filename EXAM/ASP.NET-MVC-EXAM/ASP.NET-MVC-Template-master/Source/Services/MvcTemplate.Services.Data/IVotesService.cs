namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Models;
    using System.Linq;

    public interface IVotesService
    {

        Vote GetById(int id);

        IQueryable<Vote> GetByIp(string ip);

    }
}
