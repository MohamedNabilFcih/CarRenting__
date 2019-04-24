namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepickupadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentCars", "PickUp", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentCars", "DropOff", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentCars", "DropOff");
            DropColumn("dbo.RentCars", "PickUp");
        }
    }
}
