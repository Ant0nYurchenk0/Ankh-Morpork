namespace Ankh_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeerAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsItem", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "ItemType", c => c.Int());
            AddColumn("dbo.Events", "PlayerBeer", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "PlayerBeer");
            DropColumn("dbo.Events", "ItemType");
            DropColumn("dbo.Events", "IsItem");
        }
    }
}
