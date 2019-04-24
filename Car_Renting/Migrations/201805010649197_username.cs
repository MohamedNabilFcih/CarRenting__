namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentCars", "UserUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentCars", "UserUserName");
        }
    }
}
