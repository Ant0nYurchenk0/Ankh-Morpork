namespace Ankh_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBeggrTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "MoneyFee", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "MoneyFee");
        }
    }
}
