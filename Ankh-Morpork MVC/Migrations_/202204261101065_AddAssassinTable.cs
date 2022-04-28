//namespace Ankh_Morpork_MVC.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddAssassinTable : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Assassins",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(),
//                        MaxReward = c.Double(nullable: false),
//                        MinReward = c.Double(nullable: false),
//                        IsBusy = c.Boolean(nullable: false),
//                        OfferMessage = c.String(),
//                        MeetMessage = c.String(),
//                        AcceptMessage = c.String(),
//                        DenyMessage = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//        }
        
//        public override void Down()
//        {
//            DropTable("dbo.Assassins");
//        }
//    }
//}
