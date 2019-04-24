namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "UserId");
            AddForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropColumn("dbo.Cars", "UserId");
        }
    }
}
