namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userwallet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "wallet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "wallet");
        }
    }
}
