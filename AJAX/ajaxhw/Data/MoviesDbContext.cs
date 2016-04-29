namespace ajaxhw.Data
{
    using ajaxhw.Models;
    using System.Data.Entity;

    public class MoviesDbContext : DbContext
    {

        public MoviesDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        //public virtual IDbSet<Person> People { get; set; }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }
    }
}