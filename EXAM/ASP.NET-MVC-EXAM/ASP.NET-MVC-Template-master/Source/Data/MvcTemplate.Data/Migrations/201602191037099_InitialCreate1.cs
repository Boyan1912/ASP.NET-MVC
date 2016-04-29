namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        AuthorEmail = c.String(),
                        AuthorIp = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Idea_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ideas", t => t.Idea_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Idea_Id);
            
            CreateTable(
                "dbo.Ideas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AuthorIpAddress = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterIpAddress = c.String(),
                        Points = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Idea_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ideas", t => t.Idea_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Idea_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Idea_Id", "dbo.Ideas");
            DropForeignKey("dbo.Comments", "Idea_Id", "dbo.Ideas");
            DropIndex("dbo.Votes", new[] { "Idea_Id" });
            DropIndex("dbo.Votes", new[] { "IsDeleted" });
            DropIndex("dbo.Ideas", new[] { "IsDeleted" });
            DropIndex("dbo.Comments", new[] { "Idea_Id" });
            DropIndex("dbo.Comments", new[] { "IsDeleted" });
            DropTable("dbo.Votes");
            DropTable("dbo.Ideas");
            DropTable("dbo.Comments");
        }
    }
}
