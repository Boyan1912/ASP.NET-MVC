namespace ajaxhw.Web.App_Start
{
    using ajaxhw.Data;
    using ajaxhw.Migrations;
    using System.Data.Entity;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());
            MoviesDbContext.Create().Database.Initialize(true);
        }
    }
}