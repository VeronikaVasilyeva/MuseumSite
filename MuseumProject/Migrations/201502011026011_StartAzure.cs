namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartAzure : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        CreatedTime = c.DateTime(nullable: false),
                        Text = c.String(nullable: false, maxLength: 1000),
                        IsPublished = c.Boolean(nullable: false),
                        IsCommented = c.Boolean(nullable: false),
                        Counter = c.Int(nullable: false),
                        ShortDescription = c.String(nullable: false, maxLength: 100),
                        InformationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationTypes", t => t.InformationTypeId, cascadeDelete: true)
                .Index(t => t.InformationTypeId);
            
            CreateTable(
                "dbo.InformationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDiscription = c.String(),
                        FileName = c.String(nullable: false),
                        Published = c.Boolean(nullable: false),
                        InformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.InformationId, cascadeDelete: true)
                .Index(t => t.InformationId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 1000),
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
                "dbo.Counters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Ip = c.String(),
                        InformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.InformationId, cascadeDelete: true)
                .Index(t => t.InformationId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Counters", new[] { "InformationId" });
            DropIndex("dbo.Comments", new[] { "UserProfileId" });
            DropIndex("dbo.Comments", new[] { "InformationId" });
            DropIndex("dbo.Photos", new[] { "InformationId" });
            DropIndex("dbo.Information", new[] { "InformationTypeId" });
            DropForeignKey("dbo.Counters", "InformationId", "dbo.Information");
            DropForeignKey("dbo.Comments", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Comments", "InformationId", "dbo.Information");
            DropForeignKey("dbo.Photos", "InformationId", "dbo.Information");
            DropForeignKey("dbo.Information", "InformationTypeId", "dbo.InformationTypes");
            DropTable("dbo.Counters");
            DropTable("dbo.Comments");
            DropTable("dbo.Photos");
            DropTable("dbo.InformationTypes");
            DropTable("dbo.Information");
            DropTable("dbo.UserProfile");
        }
    }
}
