namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Comment = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        InformationId = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.InformationId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.InformationId)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDiscribtion = c.String(),
                        NameFile = c.String(nullable: false),
                        Published = c.Boolean(nullable: false),
                        InformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.InformationId, cascadeDelete: true)
                .Index(t => t.InformationId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Photos", new[] { "InformationId" });
            DropIndex("dbo.Comments", new[] { "UserProfileId" });
            DropIndex("dbo.Comments", new[] { "InformationId" });
            DropForeignKey("dbo.Photos", "InformationId", "dbo.Information");
            DropForeignKey("dbo.Comments", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Comments", "InformationId", "dbo.Information");
            DropTable("dbo.Photos");
            DropTable("dbo.Comments");
        }
    }
}
