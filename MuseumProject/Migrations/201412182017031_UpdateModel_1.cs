namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Information", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Information", "Text", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Information", "ShortDescription", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Information", "ShortDescription", c => c.String());
            AlterColumn("dbo.Information", "Text", c => c.String());
            AlterColumn("dbo.Information", "Title", c => c.String(nullable: false));
        }
    }
}
