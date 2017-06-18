namespace MuseumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "ShortDiscription", c => c.String());
            AddColumn("dbo.Photos", "FileName", c => c.String(nullable: false));
            Sql("UPDATE dbo.Photos SET ShortDiscription = ShortDescription");
            Sql("UPDATE dbo.Photos SET FileName = NameFile");
            AlterColumn("dbo.Comments", "Comment", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Photos", "ShortDescription");
            DropColumn("dbo.Photos", "NameFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "NameFile", c => c.String(nullable: false));
            AddColumn("dbo.Photos", "ShortDescription", c => c.String());
            Sql("UPDATE dbo.Photos SET ShortDescription = ShortDiscription");
            Sql("UPDATE dbo.Photos SET NameFile = FileName");
            AlterColumn("dbo.Comments", "Comment", c => c.String(nullable: false));
            DropColumn("dbo.Photos", "FileName");
            DropColumn("dbo.Photos", "ShortDiscription");
        }
    }
}
