namespace Ankh_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatistics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MeetMessage = c.String(),
                        GuildData = c.String(),
                        MaxReward = c.Double(),
                        MinReward = c.Double(),
                        IsBusy = c.Boolean(),
                        OfferMessage = c.String(),
                        MoneyFee = c.Double(),
                        BeerFee = c.Boolean(),
                        Reward = c.Double(),
                        ItemType = c.Int(),
                        Price = c.Double(),
                        Fee = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        PlayerMoney = c.Double(nullable: false),
                        PlayerBeer = c.Double(nullable: false),
                        PlayerHood = c.Double(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePlayed = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Events", new[] { "CharacterId" });
            DropTable("dbo.Games");
            DropTable("dbo.Events");
            DropTable("dbo.Characters");
        }
    }
}
