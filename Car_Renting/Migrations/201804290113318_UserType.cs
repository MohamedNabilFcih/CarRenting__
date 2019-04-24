namespace Car_Renting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Usertype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Usertype");
        }
    }
}
