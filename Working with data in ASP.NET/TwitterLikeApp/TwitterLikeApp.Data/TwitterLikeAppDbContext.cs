namespace TwitterLikeApp.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class TwitterLikeAppDbContext : IdentityDbContext<User>
    {
        public TwitterLikeAppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public virtual IDbSet<Twit> Twits { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public static TwitterLikeAppDbContext Create()
        {
            return new TwitterLikeAppDbContext();
        }
    }
}
