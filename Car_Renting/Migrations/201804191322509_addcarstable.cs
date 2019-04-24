namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcarstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    { 
                        id = c.Int(nullable: false, identity: true),
                        cardesc = c.String(),
                        carimg = c.String(),
                        price = c.Int(nullable: false),
                        categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.categoryid, cascadeDelete: true)
                .Index(t => t.categoryid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "categoryid", "dbo.categories");
            DropIndex("dbo.Cars", new[] { "categoryid" });
            DropTable("dbo.Cars");
        }
    }
}
