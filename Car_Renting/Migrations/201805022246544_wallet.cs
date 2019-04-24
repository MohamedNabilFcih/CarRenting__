namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wallet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "wallet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "wallet");
        }
    }
}
