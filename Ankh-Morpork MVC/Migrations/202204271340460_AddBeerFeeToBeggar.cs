namespace Ankh_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBeerFeeToBeggar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "BeerFee", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "BeerFee");
        }
    }
}
