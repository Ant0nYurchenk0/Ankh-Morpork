//namespace Ankh_Morpork_MVC.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class UpdateDb : DbMigration
//    {
//        public override void Up()
//        {
//            AddColumn("dbo.Characters", "ItemType", c => c.Int());
//            DropColumn("dbo.Events", "IsItem");
//            DropColumn("dbo.Events", "ItemType");
//        }
        
//        public override void Down()
//        {
//            AddColumn("dbo.Events", "ItemType", c => c.Int());
//            AddColumn("dbo.Events", "IsItem", c => c.Boolean(nullable: false));
//            DropColumn("dbo.Characters", "ItemType");
//        }
//    }
//}
