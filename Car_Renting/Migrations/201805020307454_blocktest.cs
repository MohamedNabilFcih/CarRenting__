namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blocktest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IsBlocked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsBlocked", c => c.Byte(nullable: false));
        }
    }
}
