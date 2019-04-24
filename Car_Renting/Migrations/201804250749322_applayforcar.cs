namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applayforcar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "location", c => c.String());
            AddColumn("dbo.Cars", "PickUp", c => c.String());
            AddColumn("dbo.Cars", "DropOff", c => c.String());
            AddColumn("dbo.Cars", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "user_Id");
            AddForeignKey("dbo.Cars", "user_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "user_Id" });
            DropColumn("dbo.Cars", "user_Id");
            DropColumn("dbo.Cars", "DropOff");
            DropColumn("dbo.Cars", "PickUp");
            DropColumn("dbo.Cars", "location");
        }
    }
}
