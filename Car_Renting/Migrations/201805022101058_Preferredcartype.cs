namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Preferredcartype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PreferredCart", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PreferredCart");
        }
    }
}
