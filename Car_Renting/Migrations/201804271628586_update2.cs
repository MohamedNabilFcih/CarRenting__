namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "location");
            DropColumn("dbo.AspNetUsers", "PickUp");
            DropColumn("dbo.AspNetUsers", "DropOff");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DropOff", c => c.String());
            AddColumn("dbo.AspNetUsers", "PickUp", c => c.String());
            AddColumn("dbo.AspNetUsers", "location", c => c.String());
        }
    }
}
