namespace MuseumProject.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class deleteBaseInformationTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BaseInformations");
        }
        
        public override void Down()
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
    }
}
