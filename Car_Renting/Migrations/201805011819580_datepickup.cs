namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepickup : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentCars", "PUDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentCars", "PUDate", c => c.DateTime(nullable: false));
        }
    }
}
