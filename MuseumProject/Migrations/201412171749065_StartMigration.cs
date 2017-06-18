namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        Text = c.String(),
                        IsPublished = c.Boolean(nullable: false),
                        IsCommented = c.Boolean(nullable: false),
                        Counter = c.Int(nullable: false),
                        ShortDescription = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Information", new[] { "InformationTypeId" });
            DropForeignKey("dbo.Information", "InformationTypeId", "dbo.InformationTypes");
            DropTable("dbo.InformationTypes");
            DropTable("dbo.Information");
            DropTable("dbo.UserProfile");
        }
    }
}
