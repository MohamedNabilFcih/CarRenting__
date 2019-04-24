namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "user_Id" });
            CreateTable(
                "dbo.RentCars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        location = c.String(nullable: false),
                        PickUp = c.String(nullable: false),
                        DropOff = c.String(nullable: false),
                        CarId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.UserId);
            
            DropColumn("dbo.Cars", "location");
            DropColumn("dbo.Cars", "PickUp");
            DropColumn("dbo.Cars", "DropOff");
            DropColumn("dbo.Cars", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "user_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Cars", "DropOff", c => c.String());
            AddColumn("dbo.Cars", "PickUp", c => c.String());
            AddColumn("dbo.Cars", "location", c => c.String());
            DropForeignKey("dbo.RentCars", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RentCars", "CarId", "dbo.Cars");
            DropIndex("dbo.RentCars", new[] { "UserId" });
            DropIndex("dbo.RentCars", new[] { "CarId" });
            DropTable("dbo.RentCars");
            CreateIndex("dbo.Cars", "user_Id");
            AddForeignKey("dbo.Cars", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
