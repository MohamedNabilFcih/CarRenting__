namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentCars", "PickUp");
            DropColumn("dbo.RentCars", "DropOff");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentCars", "DropOff", c => c.String(nullable: false));
            AddColumn("dbo.RentCars", "PickUp", c => c.String(nullable: false));
        }
    }
}
