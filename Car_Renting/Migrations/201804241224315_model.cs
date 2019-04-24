namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "color", c => c.String());
            AddColumn("dbo.Cars", "numchairs", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "model", c => c.String());
            AddColumn("dbo.Cars", "avaliable", c => c.String());
            AddColumn("dbo.Cars", "applaydate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "userapplay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "userapplay");
            DropColumn("dbo.Cars", "applaydate");
            DropColumn("dbo.Cars", "avaliable");
            DropColumn("dbo.Cars", "model");
            DropColumn("dbo.Cars", "numchairs");
            DropColumn("dbo.Cars", "color");
        }
    }
}
