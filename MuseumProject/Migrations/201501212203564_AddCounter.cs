namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCounter : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.Counters", "InformationId", "dbo.Information");
            DropTable("dbo.Counters");
        }
    }
}
