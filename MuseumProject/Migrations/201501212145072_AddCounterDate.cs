namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCounterDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Counters", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Counters", "Date");
        }
    }
}
