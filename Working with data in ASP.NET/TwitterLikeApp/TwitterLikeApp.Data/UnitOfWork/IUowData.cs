namespace TwitterLikeApp.Data.UnitOfWork
{
    using System;
    using Repositories;
    using Models;

    public interface IUowData : IDisposable
    {
        IRepository<Twit> Twits { get; }

        IRepository<Tag> Tags { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
