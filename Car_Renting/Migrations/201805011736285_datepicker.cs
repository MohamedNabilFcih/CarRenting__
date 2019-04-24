namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datepicker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentCars", "PUDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentCars", "PUDate");
        }
    }
}
