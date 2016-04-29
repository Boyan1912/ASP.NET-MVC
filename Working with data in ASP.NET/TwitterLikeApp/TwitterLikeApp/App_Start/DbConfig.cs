namespace TwitterLikeApp.App_Start
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DbConfig
    {

        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterLikeAppDbContext, Configuration>());
            TwitterLikeAppDbContext.Create().Database.Initialize(true);
        }


    }
}