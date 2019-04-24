namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "location", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PickUp", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "DropOff", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DropOff", c => c.String());
            AlterColumn("dbo.AspNetUsers", "PickUp", c => c.String());
            AlterColumn("dbo.AspNetUsers", "location", c => c.String());
        }
    }
}
