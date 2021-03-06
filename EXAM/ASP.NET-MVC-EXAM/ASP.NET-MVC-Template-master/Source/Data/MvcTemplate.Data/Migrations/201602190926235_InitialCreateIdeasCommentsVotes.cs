namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateIdeasCommentsVotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IpAddress");
        }
    }
}
