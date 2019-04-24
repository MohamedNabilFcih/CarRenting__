namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "location", c => c.String());
            AddColumn("dbo.AspNetUsers", "PickUp", c => c.String());
            AddColumn("dbo.AspNetUsers", "DropOff", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DropOff");
            DropColumn("dbo.AspNetUsers", "PickUp");
            DropColumn("dbo.AspNetUsers", "location");
        }
    }
}
