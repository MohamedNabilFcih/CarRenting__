namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropwallet : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "wallet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "wallet", c => c.String());
        }
    }
}
