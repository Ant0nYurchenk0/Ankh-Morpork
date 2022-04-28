//namespace Ankh_Morpork_MVC.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddEventsTable : DbMigration
//    {
//        public override void Up()
//        {
//            RenameTable(name: "dbo.Assassins", newName: "Characters");
//            CreateTable(
//                "dbo.Events",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        CharacterId = c.Int(nullable: false),
//                        PlayerMoney = c.Double(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
//                .Index(t => t.CharacterId);
            
//            AddColumn("dbo.Characters", "Discriminator", c => c.String(nullable: false, maxLength: 128));
//            AlterColumn("dbo.Characters", "MaxReward", c => c.Double());
//            AlterColumn("dbo.Characters", "MinReward", c => c.Double());
//            AlterColumn("dbo.Characters", "IsBusy", c => c.Boolean());
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.Events", "CharacterId", "dbo.Characters");
//            DropIndex("dbo.Events", new[] { "CharacterId" });
//            AlterColumn("dbo.Characters", "IsBusy", c => c.Boolean(nullable: false));
//            AlterColumn("dbo.Characters", "MinReward", c => c.Double(nullable: false));
//            AlterColumn("dbo.Characters", "MaxReward", c => c.Double(nullable: false));
//            DropColumn("dbo.Characters", "Discriminator");
//            DropTable("dbo.Events");
//            RenameTable(name: "dbo.Characters", newName: "Assassins");
//        }
//    }
//}
