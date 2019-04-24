namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "applaydate");
            DropColumn("dbo.Cars", "userapplay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "userapplay", c => c.String());
            AddColumn("dbo.Cars", "applaydate", c => c.DateTime(nullable: false));
        }
    }
}
