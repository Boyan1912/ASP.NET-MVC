namespace ajaxhw.Migrations
{
    using ajaxhw.Models;
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            for (int i = 0; i < 10; i++)
            {
                context.Movies.AddOrUpdate(
              m => m.Title,
              new Movie { Title = "X-Files Season " + i, Director = "Director " + i, LeadingMaleRole = "John " + i,  LeadingMaleActorAge = 50 + i, Year = 2000 + i },
              new Movie { Title = "Clockwork Orange " + i, Director = "Someone " + i + i, LeadingFemaleRole = "Jane " + i , LeadingFemaleActorAge = 18 + i, Year = 1990 + i},
              new Movie { Title = "Gone with the wind " + i, Director = "Clint Eastwood", LeadingMaleRole = "Buggs Bunny " + (i * i).ToString(), LeadingMaleActorAge = 20 + i, Year = 2010 + i }
            );
            }


            

        }
    }
}
