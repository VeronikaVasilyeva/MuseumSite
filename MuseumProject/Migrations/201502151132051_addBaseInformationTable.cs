namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBaseInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BaseInformations");
        }
    }
}
